using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TodoList.Interfaces;
using TodoList.Utils;

namespace TodoList.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private readonly CategoryRepositoryManager _manager;
        
        public CategoryListViewComponent(CategoryRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var repos = _manager.GetCategoryRepository();
            
            var categories = await repos.GetAllCategoriesAsync();

            return View(categories);
        }
    }
}
