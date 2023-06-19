using TodoList.Models;
using TodoList.Models.DTOs.DisplayDtos;

namespace TodoList.Interfaces
{
	public interface ITaskRepository
	{
		public Task<TaskViewModel> AddTaskAsync(TaskViewModel task);

		public Task UpdateTaskAsync(TaskViewModel task,int id);

		public Task DeleteTaskAsync(int id);

		public Task UpdateCompletionState(bool state, int id);

		public Task<TaskViewModel?> GetTaskByIdAsync(int id);

		public Task<List<TaskViewModel>> GetAllTasksAsync();

		public Task<IEnumerable<TaskViewModel>> GetTasksWith<T>(Func<TaskViewModel,T,TaskViewModel>? map=null,string spitOn="");
	}
}
