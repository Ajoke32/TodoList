using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TodoList.Interfaces;
using TodoList.Models;
using AutoMapper;
using TodoList.Models.InputDTOs;
using TodoList.Utils.Enums;
using TodoList.Utils;

namespace TodoList.Controllers
{
	public class TaskController : Controller
	{


		private ITaskRepository _taskRepository;

		private readonly IMapper _mapper;
		public TaskController(IMapper mapper,IConfiguration configuration,TaskRepositoryManager manager)
		{
			_taskRepository = manager.GetTaskRepository();
			_mapper = mapper;
		}

		public async Task<IActionResult> UpdateState(bool state,int id)
		{
		   await _taskRepository.UpdateCompletionState(state,id);

		   return RedirectToAction("Tasks");
		}
		
		
		[HttpPost]
		public async Task<IActionResult> Update(TaskInputViewModel task,int id)
		{
			var _task = _mapper.Map<TaskViewModel>(task);
			await _taskRepository.UpdateTaskAsync(_task,id);
			return RedirectToAction("Tasks");
		}

		[HttpPost]
		public async Task<IActionResult> Remove(int id)
		{

			await _taskRepository.DeleteTaskAsync(id);
			
			return RedirectToAction("Tasks");
		}


		[HttpPost]
		public async Task<IActionResult> Tasks(TaskInputViewModel task)
		{
		
			if (ModelState.IsValid)
			{
				var _task = _mapper.Map<TaskViewModel>(task);
				
				await _taskRepository.AddTaskAsync(_task);
				
				return RedirectToAction("Tasks");
			}

			return View();
		}

		[HttpGet]
		public  IActionResult Tasks()
		{
			return View();
		}
		
		public IActionResult ChangeStore()
		{
			StorageState.ChangeState();
			return RedirectToAction("Tasks");
		}

	}
}
