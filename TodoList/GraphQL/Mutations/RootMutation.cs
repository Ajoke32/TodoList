using GraphQL.MicrosoftDI;
using GraphQL.Types;

namespace TodoList.GraphQL.Mutations;

public class RootMutation : ObjectGraphType
{
    public RootMutation()
    {
        Field<TaskMutation>()
            .Name("Todo")
            .Resolve(_ => new { });

        Field<CategoryMutation>()
            .Name("Category")
            .Resolve(_ => new { });
    }
}