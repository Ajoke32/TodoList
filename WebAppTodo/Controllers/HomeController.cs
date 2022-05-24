using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppTodo.Models;
using WebAppTodo.ModelXml;
using System.Xml;
using WebAppTodo.MyServices;


namespace WebAppTodo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration Configuration;
        private ITaskRepository _taskRepository;
        private IWebHostEnvironment Environment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment,
            ITaskRepository taskRepositoryXml)
        {
            _logger = logger;
            Environment = environment;
            _taskRepository = taskRepositoryXml;
        }
        [HttpGet]
        public IActionResult Index()
        {

            TaskRepositoryList model = new TaskRepositoryList();

            model.Taskes = _taskRepository.GetTask().ToList();
            model.Categories = _taskRepository.GetCategories().ToList();

            return View(model);
        }


        [HttpPost]
        public IActionResult CreateTask(Tasks tasks)
        {

            _taskRepository.CreateTask(tasks);

            return Redirect("Index");

        }
        [HttpPost]
        public IActionResult DeleteTasks(int TaskId)
        {
            TaskRepositoryList model = new TaskRepositoryList();

            _taskRepository.DeleteTask(TaskId);

            return Redirect("Index");
        }
        [HttpPost]
        public IActionResult CompleteTasks(int TaskId)
        {
            _taskRepository.TaskIsComplete(TaskId);
            return Redirect("Index");
        }
        [HttpPost]
        public IActionResult Filter(Tasks tasks)
        {
            TaskRepositoryList model = new TaskRepositoryList();

            model.Taskes = _taskRepository.FilterByCategory(tasks);
            model.Categories = _taskRepository.GetCategories().ToList();
            _taskRepository.FilterByTime();

            return View("Index", model);
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

            return Redirect("CategoryList");
        }
        [HttpPost]
        public IActionResult DeleteCategory(int CategoryId)
        {
            TaskRepositoryList model = new TaskRepositoryList();

            _taskRepository.DeleteCategory(CategoryId);

            return Redirect("CategoryList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}