using GraphQL.Types;
using TodoList.GraphQL.GrapthQLTypes;
using TodoList.GraphQL.Mutations;
using TodoList.GraphQL.Queries;
using TodoList.Models;

namespace TodoList.GraphQL.Schemes;

public class AppSchema : Schema
{
    public AppSchema(IServiceProvider provider):base(provider)
    {
        RegisterTypeMapping(typeof(Category),typeof(CategoryType));
        Query = provider.GetRequiredService<RootQuery>();
        Mutation = provider.GetRequiredService<RootMutation>();
    }
}