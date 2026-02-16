using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTodoApp.API.Entities;

public class TodoTask
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Description { get; set; }
    public bool IsDone { get; set; } = false;
    [ForeignKey("TodoId")]
    public Todo? TodoItem { get; set; }
    public int TodoId { get; set; }

    public TodoTask(string description)
    {
        Description = description;
    }
}