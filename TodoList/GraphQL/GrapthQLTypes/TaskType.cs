using System;
using GraphQL.Types;
using TodoList.Models;

namespace TodoList.GraphQL.GrapthQLTypes
{
	public sealed class TaskType : ObjectGraphType<TaskViewModel>
	{
		public TaskType()
		{
			
			Field(x=>x.Id).Description("Id prop");
			Field(x=>x.Title).Description("Task title");
			Field(x=>x.ExpirationDate,nullable:true).Description("Task deadline");
			Field(x=>x.IsCompleted).Description("Task completion state");
			Field(x=>x.CategoryId).Description("Task category id");
			Field(x=>x.Category,nullable:true).Description("Task category");
		}
	}
}
