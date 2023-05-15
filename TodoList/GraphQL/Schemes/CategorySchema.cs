using System;
using GraphQL.Types;
using TodoList.GraphQL.Mutations;
using TodoList.GraphQL.Queries;

namespace TodoList.GraphQL.Schemes
{
	public class CategorySchema : Schema
	{
		public CategorySchema(IServiceProvider provider):base(provider)
		{
			Query = provider.GetRequiredService<CategoryQuery>();
			Mutation = provider.GetRequiredService<CategoryMutation>();
		}
	}
}
