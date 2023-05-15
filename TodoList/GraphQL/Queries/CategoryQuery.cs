using System;
using GraphQL;
using GraphQL.Types;
using TodoList.GraphQL.GrapthQLTypes;
using TodoList.Interfaces;
#pragma warning disable CS0618
namespace TodoList.GraphQL.Queries
{
	public class CategoryQuery: ObjectGraphType
	{
		private ICategoryRepository _repository;
		public CategoryQuery(ICategoryRepository repos)
		{
			_repository = repos;
			FieldAsync<ListGraphType<CategoryType>>("categories",
			 "gets all categories",
			 resolve: async context =>
			 {
				 return await _repository.GetAllCategoriesAsync();
			 }
			);
			
			FieldAsync<CategoryType>("getById",
			  arguments:new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>>(){Name="id"}),
			  resolve:async context=>
			  {
			  	 int id = context.GetArgument<int>("id");
				 
				 return await _repository.GetCategoryById(id);
			  }
			);
			
		}
		
	}
}
