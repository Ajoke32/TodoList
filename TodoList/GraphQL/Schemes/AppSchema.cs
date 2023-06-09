using GraphQL.Types;
using TodoList.GraphQL.Mutations;
using TodoList.GraphQL.Queries;

namespace TodoList.GraphQL.Schemes;

public class AppSchema : Schema
{
    public AppSchema(IServiceProvider provider):base(provider)
    {
        Query = provider.GetRequiredService<RootQuery>();
        Mutation = provider.GetRequiredService<RootMutation>();
    }
}