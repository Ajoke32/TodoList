using System;
using GraphQL.Types;

namespace TodoList.GraphQL.GrapthQLTypes.InputTypes
{
	public class CategoryUpdateType:InputObjectGraphType
	{
		public CategoryUpdateType()
		{
			Field<NonNullGraphType<IntGraphType>>("id");
			Field<NonNullGraphType<StringGraphType>>("title");
		}
	}
}
