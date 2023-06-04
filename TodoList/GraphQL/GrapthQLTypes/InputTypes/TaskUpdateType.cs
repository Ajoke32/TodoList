using System;
using GraphQL.Types;

namespace TodoList.GraphQL.GrapthQLTypes.InputTypes
{
	public class TaskUpdateType : InputObjectGraphType
	{
		public TaskUpdateType()
		{
			Name = "updateTask";
			Field<NonNullGraphType<IntGraphType>>("id");
			Field<NonNullGraphType<StringGraphType>>("title");
			Field<DateGraphType>("expirationDate");
			Field<NonNullGraphType<IntGraphType>>("categoryId");
			Field<NonNullGraphType<BooleanGraphType>>("isCompleted");
		}
	}
}
