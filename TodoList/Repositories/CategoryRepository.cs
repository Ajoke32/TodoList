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
				_connectionString=connectionString;
		}
		public async Task<List<Category>> GetAllCategoriesAsync()
		{
			using var connection = new SqlConnection(_connectionString);

			var categories = await connection.QueryAsync<Category>("select * from Categories");

			return categories.ToList();
		}
	}
}
