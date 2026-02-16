using MyTodoApp.API.Entities;

namespace MyTodoApp.API.DbContext;
using Microsoft.EntityFrameworkCore;

public class TodoDataContext : DbContext
{
    public DbSet<Todo>  Todos { get; set; }
    public DbSet<TodoTask>  Tasks { get; set; }

    public TodoDataContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
            .HasData(
                new Todo("Rydde garasjen")
                {
                    Id = 1,
                    Priority = Priority.Low,
                    IsDone = false,
                },
                new Todo("Ta oppvasken")
                {
                    Id = 2,
                    DueDate = DateTime.Today,
                    Priority = Priority.High
                },
                new Todo("Handle matvarer")
                {
                    Id = 3,
                    Title = "Handle matvarer"
                },
                new Todo("Hente pakke")
                {
                    Id = 4,
                    IsDone = true,
                    Description = "Luftfukter"
                });
        modelBuilder.Entity<TodoTask>()
            .HasData(
                new TodoTask("Gulost")
                {
                    Id = 1,
                    TodoId = 3
                },
                new TodoTask("Skinke")
                {
                    Id = 2,
                    TodoId = 3
                });
        base.OnModelCreating(modelBuilder);
    }
    
}