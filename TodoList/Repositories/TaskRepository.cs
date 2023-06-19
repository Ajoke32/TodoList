using Dapper;
using System.Data.SqlClient;
using System.Text;
using TodoList.Interfaces;
using TodoList.Models;
using TodoList.Models.DTOs.DisplayDtos;

namespace TodoList.Repositories
{
	public class TaskRepository : ITaskRepository
	{
		private readonly string _connectionString;
		public TaskRepository(string connection)
		{
			_connectionString = connection;
		}
		

		public async Task<IEnumerable<TaskViewModel>> GetTasksWith<T>(Func<TaskViewModel, T, TaskViewModel>? map = null, string spitOn = "")
		{
			await using var connection = new SqlConnection(_connectionString);

			var tasks = await connection.QueryAsync<TaskViewModel, T, TaskViewModel>(
				"select Tasks.*,Categories.* from Tasks" +
				" inner join Categories on Categories.Id = Tasks.CategoryId",
				map,
				spitOn
				);

			return tasks;
		}


		public async Task<TaskViewModel> AddTaskAsync(TaskViewModel task)
		{
			await using var connection = new SqlConnection(_connectionString);
			
			return await connection.QuerySingleAsync<TaskViewModel>("insert into Tasks(Title,CategoryId,ExpirationDate)" +
				"output inserted.id,inserted.Title,inserted.ExpirationDate,inserted.IsCompleted,inserted.CategoryId" +
				" values (@Title, @CategoryId, @ExpirationDate)", task);
		}

		public async Task DeleteTaskAsync(int id)
		{
			await using var connection = new SqlConnection(_connectionString);

			await connection.ExecuteAsync("delete from Tasks where Id=@Id", new { Id = id });
		}

		public async Task<List<TaskViewModel>> GetAllTasksAsync()
		{
			await using var connection = new SqlConnection(_connectionString);

			var tasks = await connection.QueryAsync<TaskViewModel>("select * from Tasks order by IsCompleted");

			return tasks.ToList();
		}

		public async Task<TaskViewModel?> GetTaskByIdAsync(int id)
		{
			await using var connection = new SqlConnection(_connectionString);

			var task = await connection.QueryFirstAsync<TaskViewModel>("select * from Tasks where Id=@Id", new { Id = id });

			return task;
		}

		public async Task UpdateCompletionState(bool state, int id)
		{
			await using var connection = new SqlConnection(_connectionString);

			await connection.ExecuteAsync("update Tasks set IsCompleted=@IsCompleted where Id=@Id", new { IsCompleted = state, Id = id });
		}

		public async Task UpdateTaskAsync(TaskViewModel task,int id)
		{
			await using var connection = new SqlConnection(_connectionString);

			await connection.ExecuteAsync("update Tasks set Title = @Title ,CategoryId=@CategoryId,ExpirationDate=@ExpirationDate," +
				"IsCompleted = @IsCompleted where Id=@Id", new 
				{
					Id=id,
					Title = task.Title,
					CategoryId = task.CategoryId,
					ExpirationDate = task.ExpirationDate,
					IsCompleted = task.IsCompleted
				});
		}
		
	}
}
