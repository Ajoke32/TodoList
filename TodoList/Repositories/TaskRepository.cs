using Dapper;
using System.Data.SqlClient;
using System.Text;
using TodoList.Interfaces;
using TodoList.Models;

namespace TodoList.Repositories
{
    public class TaskRepository:ITaskRepository
    {
        private string _connectionString;
        public TaskRepository(string connection)
        {
            _connectionString = connection;
        }

        public async Task AddTaskAsync(TaskViewModel task)
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.ExecuteAsync("insert into Tasks(Title,CategoryId,ExpirationDate,IsCompleted)" +
                "values (@Title, @CategoryId, @ExpirationDate, @IsCompleted)", task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.ExecuteAsync("delete from Tasks where Id=@Id",new {Id=id});
        }

        public async Task<List<TaskViewModel>> GetAllTasksAsync()
        {
            using var connection = new SqlConnection(_connectionString);

            var tasks = await connection.QueryAsync<TaskViewModel>("select * from Tasks");

            return tasks.ToList();
        }

        public async Task<TaskViewModel> GetTaskByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var task = await connection.QueryFirstAsync<TaskViewModel>("select * from Tasks where Id=@Id", new {Id=id});

            return task;
        }

        public async Task UpdateTaskAsync(TaskViewModel task)
        {
            using var connection = new SqlConnection(_connectionString);
            
            await connection.ExecuteAsync("update Tasks set Title = @Title ,CategoryId=@CategoryId,ExpirationDate=@ExpirationDate," +
                "IsCompleted = @IsCompleted where Id=@Id", task);
        }
    }
}
