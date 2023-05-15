using System;
using GraphQL.Types;
using TodoList.Models;

namespace TodoList.GraphQL.GrapthQLTypes
{
	public class CategoryType : ObjectGraphType<Category>
	{
	   public CategoryType()
	   {
		  Field(x=>x.Id,type:typeof(IdGraphType));
		  Field(x=>x.Title).Description("category title");
	   }
	}
}
