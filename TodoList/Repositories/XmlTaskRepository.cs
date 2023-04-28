using System;
using System.Xml.Linq;
using TodoList.Interfaces;
using TodoList.Models;
using TodoList.Models.DTOs.DisplayDtos;
using TodoList.Utils;

#pragma warning disable CS8604
#pragma warning disable CS8600
#pragma warning disable CS8619
#pragma warning disable CS8602

namespace TodoList.Repositories
{
	public class XmlTaskRepository : ITaskRepository
	{
		
		private string path = Directory.GetCurrentDirectory() + "/Tasks.xml";
		public Task AddTaskAsync(TaskViewModel task)
		{
			StreamReader reader = new StreamReader(path);
			var tasks = reader.Deserialize<TaskViewModel>().ToList();
			task.Id = tasks.Count+1;
			tasks.Add(task);
			StreamWriter wr = new StreamWriter(path);
			return wr.SaveAsync(tasks);
		}

		public async Task DeleteTaskAsync(int id)
		{
			var tasks = await GetAllTasksAsync();
			TaskViewModel task = tasks.FirstOrDefault(t => t.Id == id);
			tasks.Remove(task);
			StreamWriter wr = new StreamWriter(path);
			await wr.SaveAsync(tasks);
		}

		public Task<List<TaskViewModel>> GetAllTasksAsync()
		{
			StreamReader sr = new StreamReader(path);
			List<TaskViewModel> tasks = sr.Deserialize<TaskViewModel>().OrderBy(t=>t.IsCompleted==true).ToList();
			return Task.Run(() => tasks);
		}

		public Task<TaskViewModel> GetTaskByIdAsync(int id)
		{
			StreamReader sr = new StreamReader(path);
			List<TaskViewModel> tasks = sr.Deserialize<TaskViewModel>().ToList();

			return Task.Run(() => tasks.FirstOrDefault(t => t.Id == id));
		}

		public Task<List<DisplayTaskViewModel>> GetTaskWithCategoryName()
		{
			List<DisplayTaskViewModel> list = new List<DisplayTaskViewModel>();
			StreamReader sr = new StreamReader(path);
			List<TaskViewModel> tasks = sr.Deserialize<TaskViewModel>().ToList();
			foreach (var item in tasks)
			{
				list.Add(new DisplayTaskViewModel()
				{
					Id = item.Id,
					Title = item.Title,
					ExpirationDate = item.ExpirationDate,
					IsCompleted = item.IsCompleted,
					CategoryName = item.CategoryId.ToString(),
				});
			}

			return Task.Run(() => list.OrderBy(t=>t.IsCompleted).ToList());
		}

		public async Task UpdateCompletionState(bool state, int id)
		{
			var tasks = await GetAllTasksAsync();
			TaskViewModel task = tasks.FirstOrDefault(t => t.Id == id);
			task.IsCompleted = state;
			StreamWriter wr = new StreamWriter(path);
			await wr.SaveAsync(tasks);
		}

		public async Task UpdateTaskAsync(TaskViewModel task,int id)
		{
			var tasks = await GetAllTasksAsync();
			TaskViewModel searchTask = tasks.FirstOrDefault(t => t.Id == id);
			searchTask = task;
			StreamWriter wr = new StreamWriter(path);
			await wr.SaveAsync(tasks);
		}
	}
}
