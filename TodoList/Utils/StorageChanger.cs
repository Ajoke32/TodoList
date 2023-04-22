using System;
using TodoList.Interfaces;
using TodoList.Repositories;
using TodoList.Utils.Enums;

namespace TodoList.Utils
{
	public static class StorageChanger
	{
		private static Storage _state = Storage.Db;
		public static ITaskRepository GetTaskRepository(IConfiguration configuration)
		{
			if(_state==Storage.Db)
			{
				return new TaskRepository(configuration.GetConnectionString("DefaultConnection"));
			}else
			{
				return new XmlTaskRepository();
			}
		}
		
		public static void ChangeState()
		{
			_state = (Storage)(~(int)_state);	
		}
	}
}
