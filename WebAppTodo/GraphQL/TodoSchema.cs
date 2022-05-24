using GraphQL.Types;



namespace WebAppTodo.GraphQL
{
    public class TodoSchema:Schema
    {

        public TodoSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<TodoQuery>();
        }

    }
}
