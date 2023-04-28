using System;
using GraphQL;
using GraphQL.Types;
using TodoList.GraphQL.GrapthQLTypes;
using TodoList.GraphQL.GrapthQLTypes.InputTypes;
using TodoList.Interfaces;
using TodoList.Models;
using TodoList.Models.InputDTOs;

#pragma warning disable CS0618

namespace TodoList.GraphQL.Mutations
{
	public class TaskMutation : ObjectGraphType
	{
		public TaskMutation(ITaskRepository repository)
		{
			FieldAsync<TaskType>(
			  "createTask",
			  arguments: new QueryArguments(new QueryArgument<NonNullGraphType<TaskInputType>>(){Name="task"}),
			   
			   resolve:async context=>
			   {
			   	 var task = context.GetArgument<TaskViewModel>("task");
				 
				 await repository.AddTaskAsync(task);
				 
				 return task;
			   }
			);
			
			FieldAsync<StringGraphType>(
				"removeTask",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>>(){Name="taskId"})
				,
				resolve:async context=>
				{
					int id = context.GetArgument<int>("taskId");
					if(id==default(int))
					{
						return $"taskId argument missing";
					}
					await repository.DeleteTaskAsync(id);
					return $"task with id {id} deleted";
				}
			);
			
			FieldAsync<TaskType>(
				"updateTask",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<TaskUpdateType>>(){Name="task"}),
				resolve:async context =>
				{
					var task = context.GetArgument<TaskViewModel>("task");
					await repository.UpdateTaskAsync(task,task.Id);
					
					return await repository.GetTaskByIdAsync(task.Id);
				}
			);
			
		}
	}
}
