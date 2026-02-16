using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTodoApp.API.Entities;

public class Todo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(100)]
    public string? Description { get; set; }
    public bool IsDone { get; set; } = false;
    public DateTime? DueDate { get; set; }
    public Priority Priority { get; set; } =  Priority.Normal;
    public ICollection<TodoTask> Tasks { get; set; } = new List<TodoTask>();
    
    public Todo(string title)
    {
        Title = title;
    }
}