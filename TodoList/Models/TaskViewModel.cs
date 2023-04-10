using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TodoList.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Title field is required")]
        [NotNull]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }

        public bool IsCompleted { get; set; } 
        
        public int CategoryId { get; set; }
    }
}
