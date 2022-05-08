using Microsoft.AspNetCore.Mvc;
using WebAppTodo.MyServices;
using System.ComponentModel.DataAnnotations;
using WebAppTodo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Query;
using Dapper;

namespace WebAppTodo.Controllers
{
    public class TaskController : Controller
    {
        private IConfiguration Configuration;
        private ITaskRepository _taskRepository;
        public TaskController(IConfiguration configuration, ITaskRepository taskRepository)
        {
            Configuration = configuration;
            _taskRepository = taskRepository;
          
        }
        public IActionResult Index()
        {
            return View();
        }
      
        [HttpGet]
        public IActionResult TaskList()
        {
            TaskRepositoryList model = new TaskRepositoryList();
           
            model.Taskes = _taskRepository.GetTask().ToList();
            model.Categories = _taskRepository.GetCategories().ToList();
            
            return View(model);
        }
        
        [HttpPost]
        public IActionResult CreateTask(Tasks tasks)
        {
            TaskRepositoryList model = new TaskRepositoryList();
           
            _taskRepository.CreateTask(tasks);

            return Redirect("TaskList");

        }
        [HttpPost]
        public IActionResult DeleteTasks(int TaskId)
        {
            TaskRepositoryList model = new TaskRepositoryList();
          
            _taskRepository.DeleteTask(TaskId);

            return Redirect("TaskList");
        }
        [HttpPost]
        public IActionResult CompleteTasks(int TaskId)
        {
            _taskRepository.TaskIsComplete(TaskId);
            return Redirect("TaskList");
        }
        [HttpPost]
        public IActionResult Filter(Tasks tasks)
        {
            TaskRepositoryList model = new TaskRepositoryList();

            model.Taskes = _taskRepository.FilterByCategory(tasks);
            model.Categories = _taskRepository.GetCategories().ToList();
            _taskRepository.FilterByTime();

            return View("TaskList",model);
        }
        public IActionResult CateList()
        {
            TaskRepositoryList model = new TaskRepositoryList();
            model.Categories = _taskRepository.GetCategories().ToList();
            return View(model);
        }
        public IActionResult CreateCategory(Category category)
        {
            TaskRepositoryList model = new TaskRepositoryList();

            _taskRepository.CreateCategory(category);

            return Redirect("CateList");
        }
        [HttpPost]
        public IActionResult DeleteCategory(int CategoryId)
        {
            TaskRepositoryList model = new TaskRepositoryList();

            _taskRepository.DeleteCategory(CategoryId);

            return Redirect("CateList");
        }
    }
}
