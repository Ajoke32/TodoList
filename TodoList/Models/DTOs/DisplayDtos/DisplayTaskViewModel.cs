using System;

namespace TodoList.Models.DTOs.DisplayDtos
{
	public class DisplayTaskViewModel
	{
		public int Id {get;set;}
		public string? Title {get;set;}
		
		public string? CategoryName {get;set;}
		
		public DateTime ExpirationDate{get;set;}
		
		public bool IsCompleted {get;set;}
		
	}
}
