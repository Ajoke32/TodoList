using TodoList.Models;

namespace TodoList.Interfaces
{
    public interface ITaskRepository
    {
        public Task AddTaskAsync(TaskViewModel task);

        public Task UpdateTaskAsync(TaskViewModel task);

        public Task DeleteTaskAsync(int id);

        public Task<TaskViewModel> GetTaskByIdAsync(int id);

        public Task<List<TaskViewModel>> GetAllTasksAsync();
          
    }
}
