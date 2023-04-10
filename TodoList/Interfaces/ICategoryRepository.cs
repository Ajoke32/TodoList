
using TodoList.Models;

namespace TodoList.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllCategoriesAsync();
    }
}
