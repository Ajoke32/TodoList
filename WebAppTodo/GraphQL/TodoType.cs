using GraphQL.Types;
using WebAppTodo.Models;

namespace WebAppTodo.GraphQL
{
    public class TodoType:ObjectGraphType<Tasks>
    {

        public TodoType()
        {
            Name = "Todo";
            Description = "Todo Type";
            Field(d => d.id, nullable: false).Description("Todo Id");
            Field(d => d.Title, nullable: false).Description("Todo Title");
            Field(d => d.CategoryName, nullable:true).Description("Todo Category");
            Field(d => d.DeadLine, nullable: true).Description("Todo DeadLine");
            Field(d => d.TaskComplete, nullable: true).Description("Todo TaskComplete");
        }

    }
}
