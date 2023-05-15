using System;

namespace TodoList.Interfaces
{
    public interface ITaskRepositoryManager
    {
        public ITaskRepository GetTaskRepository();
    }
}
