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
		private readonly ITaskRepository _taskRepository;
		
		public TaskListViewComponent(TaskRepositoryManager manager)
		{
			_taskRepository = manager.GetTaskRepository();
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var task = await _taskRepository.GetTasksWith<Category>
				(((model, category) =>
				{
					model.Category = category;
					return model;
				} ),spitOn:"CategoryId");
			
			return View(task);
		}
	}
}
