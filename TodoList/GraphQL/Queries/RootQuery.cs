using GraphQL.MicrosoftDI;
using GraphQL.Types;

namespace TodoList.GraphQL.Queries;


public class RootQuery:ObjectGraphType
{
    public RootQuery()
    {
        Field<TaskQuery>()
            .Name("Todo")
            .Resolve(_ => new { });

        Field<CategoryQuery>()
            .Name("Category")
            .Resolve(_ => new {});
    }
}