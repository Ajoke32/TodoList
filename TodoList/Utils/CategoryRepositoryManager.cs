using TodoList.Interfaces;
using TodoList.Repositories;
using TodoList.Utils.Enums;

namespace TodoList.Utils;

public class CategoryRepositoryManager
{
    private readonly IConfiguration _config;
    public CategoryRepositoryManager(IConfiguration configuration)
    {
        _config = configuration;
    }
    public ICategoryRepository GetCategoryRepository()
    {
        var state = StorageState.GetState();
			
        if (state == Storage.Db)
        {
            return new CategoryRepository(_config.GetConnectionString("DefaultConnection"));
        }
        return new XmlCategoryRepository();
    }
}