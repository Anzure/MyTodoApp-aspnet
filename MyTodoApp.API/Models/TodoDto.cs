using System.ComponentModel.DataAnnotations;

namespace MyTodoApp.API.Models;

public class TodoDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsDone { get; set; } = false;
    public DateTime? DueDate { get; set; }
    public Priority Priority { get; set; } =  Priority.Normal;
    public ICollection<TaskDto> Tasks { get; set; } = new List<TaskDto>();

}