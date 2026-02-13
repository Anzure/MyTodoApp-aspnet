using System.ComponentModel.DataAnnotations;

namespace MyTodoApp.API;

public class TodoDto
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Title { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    public bool IsDone { get; set; } = false;
    public DateTime? DueDate { get; set; }
    public Priority Priority { get; set; } =  Priority.Normal;
    public ICollection<TaskDto> Tasks { get; set; } = new List<TaskDto>();

}