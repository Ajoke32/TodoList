using System;
using GraphQL;
using GraphQL.Types;
using TodoList.GraphQL.GrapthQLTypes;
using TodoList.GraphQL.GrapthQLTypes.InputTypes;
using TodoList.Interfaces;
using TodoList.Models;
#pragma warning disable CS0618
namespace TodoList.GraphQL.Mutations
{
	public class CategoryMutation:ObjectGraphType
	{
		private ICategoryRepository _repository;
		public CategoryMutation(ICategoryRepository repos)
		{
			_repository = repos;
			
			FieldAsync<CategoryType>(
			  "createCategory",
			  arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CategoryInputType>>(){Name="category"}),
			   
			   resolve:async context=>
			   {
			   	 var category = context.GetArgument<Category>("category");
				 
				 await _repository.CreateAsync(category);

				 return category;
			   }
			);
			
			FieldAsync<CategoryType>("update",
			 arguments:new QueryArguments(new QueryArgument<NonNullGraphType<CategoryUpdateType>>(){Name="category"}),
			 resolve:async context=>
			 {
				var category = context.GetArgument<Category>("category");
			 	
				await _repository.UpdateCategory(category);
				
				var updated = await _repository.GetCategoryById(category.Id);
				
				return updated;
			 }
			);
			
			FieldAsync<StringGraphType>("delete",
			 arguments:new QueryArguments(new QueryArgument<IntGraphType>(){Name="id"}),
			 resolve:async context=>
			 {
				int id = context.GetArgument<int>("id");
			 	await _repository.DeleteCategory(id);
				
				return $"Category with id {id} deleted";
			 }
			);
		}
	}
}
