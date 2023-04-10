using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TodoList.Interfaces;
using TodoList.Models;
using TodoList.Repositories;

namespace TodoList.Controllers
{
    public class TaskController : Controller
    {


        private ITaskRepository _taskRepository;

        public TaskController(ITaskRepository repository)
        {
            _taskRepository = repository;
        }

        public async Task<IActionResult> Update(TaskViewModel task)
        {
            await _taskRepository.UpdateTaskAsync(task);
            return RedirectToAction("Tasks");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
            return RedirectToAction("Tasks");
        }


        [HttpPost]
        public async Task<IActionResult> Tasks(TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                await _taskRepository.AddTaskAsync(task);
                return RedirectToAction("Tasks");
            }

            return View();
        }

        [HttpGet]
        public  IActionResult Tasks()
        {
            return View();
        }

    }
}
