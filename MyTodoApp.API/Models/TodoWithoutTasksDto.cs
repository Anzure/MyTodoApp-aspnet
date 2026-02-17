namespace MyTodoApp.API.Models;

public class TodoWithoutTasksDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsDone { get; set; } = false;
    public DateTime? DueDate { get; set; }
    public Priority Priority { get; set; } =  Priority.Normal;
}