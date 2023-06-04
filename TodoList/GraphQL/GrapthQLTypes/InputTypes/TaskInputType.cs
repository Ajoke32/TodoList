using System;
using GraphQL.Types;

namespace TodoList.GraphQL.GrapthQLTypes.InputTypes
{
	public class TaskInputType : InputObjectGraphType
	{
		public TaskInputType()
		{
			Name = "taskInput";
			
			Field<NonNullGraphType<StringGraphType>>("title");
			Field<DateTimeGraphType>("expirationDate");
			Field<NonNullGraphType<IntGraphType>>("categoryId");
		}
	}
}
