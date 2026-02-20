using System.ComponentModel.DataAnnotations;

namespace MyTodoApp.API.Models;

public class TodoCreateDto
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(50)]
    public required string Title { get; set; }
    [MaxLength(100)]
    public string? Description { get; set; }
}