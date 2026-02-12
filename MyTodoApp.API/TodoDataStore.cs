namespace MyTodoApp.API;

public class TodoDataStore
{
    public List<TaskDto> Todos { get; set; }
    
    public static TodoDataStore Instance { get; } = new TodoDataStore();

    public TodoDataStore()
    {
        Todos = new List<TaskDto>()
        {
            new TaskDto()
            {
                Id = 1,
                Title = "Rydde garasjen",
                Priority = Priority.Low
            },
            new TaskDto()
            {
                Id = 2,
                Title = "Ta oppvasken",
                DueDate = DateTime.Today,
            },
            new TaskDto()
            {
                Id = 3,
                Title = "Handle matvarer",
                Description = "Ost, Skinke, Kjøkkenpapir"
            },
            new TaskDto()
            {
                Id = 4,
                Title = "Hente pakke",
                IsDone = true
            }
        };
    }
    
}