
using TodoList.Models;

namespace TodoList.Interfaces
{
	public interface ICategoryRepository
	{
		public Task<List<Category>> GetAllCategoriesAsync();
		
		public Task<Category> CreateAsync(Category category);
		
		public Task<Category> GetCategoryById(int id);
		
		public Task UpdateCategory(Category category);
		
		public Task DeleteCategory(int id);
	}
}
