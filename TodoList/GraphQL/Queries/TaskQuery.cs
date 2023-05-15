using System;
using GraphQL;
using GraphQL.Types;
using TodoList.GraphQL.GrapthQLTypes;
using TodoList.Interfaces;
using TodoList.Models;
using TodoList.Utils;

#pragma warning disable CS0618

namespace TodoList.GraphQL.Queries
{

	public class TaskQuery : ObjectGraphType
	{
		private ITaskRepository _repository;
		public TaskQuery(ITaskRepository repos)
		{
			
			_repository = repos;
		 
			FieldAsync<ListGraphType<TaskType>>("tasks",
			 "gets all task",
			 resolve: async context =>
			 {
				 return await _repository.GetAllTasksAsync();
			 }
			);

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
					task = await _repository.GetTaskByIdAsync(id);
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
