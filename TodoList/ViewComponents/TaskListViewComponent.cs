using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TodoList.Interfaces;
using AutoMapper;
using TodoList.Models;
using TodoList.Utils.Enums;
using TodoList.Utils;

namespace TodoList.ViewComponents
{
	public class TaskListViewComponent:ViewComponent
	{
		private ITaskRepository _taskRepository;

		private IConfiguration _configuration;
		public TaskListViewComponent(IConfiguration configuration,TaskRepositoryManager manager)
		{
			_taskRepository = manager.GetTaskRepository();
			_configuration = configuration;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
			
			var task = await _taskRepository.GetTaskWithCategoryName();
			
			return View(task);
		}
	}
}
