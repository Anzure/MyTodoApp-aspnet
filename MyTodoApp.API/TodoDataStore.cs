namespace MyTodoApp.API;

public class TodoDataStore
{
    public List<TodoDto> Todos { get; set; }
    
    //public static TodoDataStore Instance { get; } = new TodoDataStore();

    public TodoDataStore()
    {
        Todos = new List<TodoDto>()
        {
            new TodoDto()
            {
                Id = 1,
                Title = "Rydde garasjen",
                Priority = Priority.Low,
                IsDone = false,
            },
            new TodoDto()
            {
                Id = 2,
                Title = "Ta oppvasken",
                DueDate = DateTime.Today,
                Priority = Priority.High
            },
            new TodoDto()
            {
                Id = 3,
                Title = "Handle matvarer",
                Tasks = new List<TaskDto>()
                {
                    new TaskDto() {
                        Id = 1,
                        Description = "Gulost"
                    },
                    new TaskDto()
                    {
                        Id = 2,
                        Description = "Skinke"
                    }
                }
            },
            new TodoDto()
            {
                Id = 4,
                Title = "Hente pakke",
                IsDone = true,
                Description = "Luftfukter"
            }
        };
    }
    
}