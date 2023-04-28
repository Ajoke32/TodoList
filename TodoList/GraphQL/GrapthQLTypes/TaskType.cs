using System;
using GraphQL.Types;
using TodoList.Models;

namespace TodoList.GraphQL.GrapthQLTypes
{
	public class TaskType : ObjectGraphType<TaskViewModel>
	{
		public TaskType()
		{
			Field(x=>x.Id,type:typeof(IdGraphType)).Description("Id prop");
			Field(x=>x.Title).Description("Task title");
			Field(x=>x.ExpirationDate,nullable:true).Description("Task deadine");
			Field(x=>x.IsCompleted).Description("Task completion state");
			Field(x=>x.CategoryId).Description("Task category id");
		}
	}
}
