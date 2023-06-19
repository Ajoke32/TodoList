using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TodoList.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public bool IsCompleted { get; set; } 
        
        public int CategoryId { get; set; }
        
        public Category? Category { get; set; }
    }
}
