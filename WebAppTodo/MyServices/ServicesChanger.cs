namespace WebAppTodo.MyServices
{
    public static class ServicesChanger
    {
        public static ITaskRepository GetServices(ITaskRepository taskRepository, IServiceProvider provider)
        {
            switch (StateStore.StorageSource)
            {
                case "Xml":
                    taskRepository = provider.GetService<TaskActionRepository>();
                    break;
                case "DataBase":
                    taskRepository = provider.GetService<TaskRepository>();
                    break;
                default:
                    taskRepository = provider.GetService<TaskRepository>();
                    break;
            }
            return taskRepository;
        }
    }
}
