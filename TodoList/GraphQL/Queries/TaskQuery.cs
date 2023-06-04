using System;
using GraphQL;
using GraphQL.Introspection;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoList.GraphQL.GrapthQLTypes;
using TodoList.Interfaces;
using TodoList.Models;
using TodoList.Utils;

#pragma warning disable CS0618

namespace TodoList.GraphQL.Queries
{
	public class SomeType
	{
		public List<string> Titels { get; set; }
	}

	public sealed class TaskQuery : ObjectGraphType
	{
		public TaskQuery(ITaskRepository repos)
		{
			var repository = repos;
			
			
			FieldAsync<ListGraphType<TaskType>>("tasks",
			 "gets all task",
			 resolve: async context => await repository.GetAllTasksAsync());


		
			
			FieldAsync<TaskType>("task", "gets task by id",
			arguments: new QueryArguments(
			 new QueryArgument<NonNullGraphType<IdGraphType>>()
			 {
				 Name = "taskId"
			 }
			),
			resolve: async context =>
			{
				int id = context.GetArgument<int>("taskId");
				TaskViewModel? task = null;
				try
				{
					task = await repository.GetTaskByIdAsync(id);
				}
				catch
				{
					context.Errors.Add(new ExecutionError("task not found"));
				}
				return task;
			}
			);

		}

	}
}
