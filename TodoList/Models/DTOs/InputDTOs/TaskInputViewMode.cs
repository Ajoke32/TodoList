
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TodoList.Models.InputDTOs;

public class TaskInputViewModel
{
    [Required(ErrorMessage = "Title field is required")]
    [NotNull]
    public string? Title { get; set; }

    [DataType(DataType.Date)]
    public DateTime? ExpirationDate { get; set; }

    [Required]
    public int CategoryId { get; set; }
}