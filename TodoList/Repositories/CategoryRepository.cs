using Dapper;
using System.Data.SqlClient;
using TodoList.Interfaces;
using TodoList.Models;

namespace TodoList.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly string _connectionString;
		public CategoryRepository(string connectionString)
		{
			_connectionString = connectionString;
		}
		public async Task<List<Category>> GetAllCategoriesAsync()
		{
			using var connection = new SqlConnection(_connectionString);

			var categories = await connection.QueryAsync<Category>("select * from Categories");

			return categories.ToList();
		}

		public async Task CreateAsync(Category category)
		{
			using var connection = new SqlConnection(_connectionString);

			await connection.ExecuteAsync("insert into Categories(Title) values (@Title)", category);
		}

		public async Task<Category> GetCategoryById(int id)
		{
			using var connection = new SqlConnection(_connectionString);

			var category = await connection.QueryFirstAsync<Category>("select * from Categories where Id=@Id", new { Id = id });

			return category;
		}

		public async Task UpdateCategory(Category category)
		{
			using var connection = new SqlConnection(_connectionString);

			await connection.ExecuteAsync("Update Categories set Title=@Title where Id=@Id", category);
		}

		public async Task DeleteCategory(int id)
		{
			using var connection = new SqlConnection(_connectionString);
			
			await connection.ExecuteAsync("delete Categories where Id=@Id", new {Id=id});
		}
	}
}
