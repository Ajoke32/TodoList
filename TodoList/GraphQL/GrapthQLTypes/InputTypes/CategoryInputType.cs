using System;
using GraphQL.Types;
using TodoList.Models;

namespace TodoList.GraphQL.GrapthQLTypes.InputTypes
{
    public class CategoryInputType:InputObjectGraphType
    {
          public CategoryInputType()
          {
            Field<NonNullGraphType<StringGraphType>>("title");
          }
    }
}
