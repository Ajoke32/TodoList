using System;
using GraphQL.Types;
using TodoList.GraphQL.GrapthQLTypes;
using TodoList.GraphQL.Mutations;
using TodoList.GraphQL.Queries;
using TodoList.Models;

namespace TodoList.GraphQL.AppSchema
{
    public class TaskSchema : Schema
    {
        public TaskSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<TaskQuery>();
            Mutation = provider.GetRequiredService<TaskMutation>();

        }
    }
}
