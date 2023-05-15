using System;
using TodoList.Interfaces;
using TodoList.Repositories;
using TodoList.Utils.Enums;

namespace TodoList.Utils
{
	public class TaskRepositoryManager : ITaskRepositoryManager
	{
		private IConfiguration _config;
		public TaskRepositoryManager(IConfiguration configuration)
		{
			_config = configuration;
		}
		public ITaskRepository GetTaskRepository()
		{
			var state = StorageState.GetState();
			if (state == Storage.Db)
			{
				return new TaskRepository(_config.GetConnectionString("DefaultConnection"));
			}
			else
			{
				return new XmlTaskRepository();
			}
		}

	}
}
