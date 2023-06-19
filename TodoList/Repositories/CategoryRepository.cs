﻿using Dapper;
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
			await using var connection = new SqlConnection(_connectionString);

			var categories = await connection.QueryAsync<Category>("select * from Categories");

			return categories.ToList();
		}

		public async Task<Category> CreateAsync(Category category)
		{
			await using var connection = new SqlConnection(_connectionString);

			return await connection.QuerySingleAsync<Category>("insert into Categories(Title)" +
			                              "output inserted.id,inserted.title" +
			                              " values (@Title)", category);
		}

		public async Task<Category?> GetCategoryById(int id)
		{
			await using var connection = new SqlConnection(_connectionString);

			var category = await connection.QueryFirstAsync<Category>("select * from Categories where Id=@Id", new { Id = id });

			return category;
		}

		public async Task UpdateCategory(Category category)
		{
			await using var connection = new SqlConnection(_connectionString);

			await connection.ExecuteAsync("Update Categories set Title=@Title where Id=@Id", category);
		}

		public async Task DeleteCategory(int id)
		{
			await using var connection = new SqlConnection(_connectionString);
			
			await connection.ExecuteAsync("delete Categories where Id=@Id", new {Id=id});
		}
	}
}
