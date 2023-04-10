using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TodoList.Interfaces;

namespace TodoList.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryRepository _categoryRepository;

        private IConfiguration _configuration;
        public CategoryListViewComponent(ICategoryRepository categoryRepo, IConfiguration configuration)
        {
            _categoryRepository = categoryRepo;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var categories = await _categoryRepository.GetAllCategoriesAsync();

            return View(categories);
        }
    }
}
