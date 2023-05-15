using System;
using TodoList.Interfaces;
using TodoList.Repositories;
using TodoList.Utils.Enums;

namespace TodoList.Utils
{
	internal static class StorageState
	{
		private static Storage _state = Storage.Db;
		public static Storage GetState()
		{
			return _state;
		}
		public static void ChangeState()
		{
			_state = _state==Storage.Db?Storage.Xml:Storage.Db;	
		}
	}
}
