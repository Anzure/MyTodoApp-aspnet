namespace MyTodoApp.API;

public class TodoDataStore
{
    public List<TodoDto> Todos { get; set; }
    
    public static TodoDataStore Instance { get; } = new TodoDataStore();

    public TodoDataStore()
    {
        Todos = new List<TodoDto>()
        {
            new TodoDto()
            {
                Id = 1,
                Title = "Rydde garasjen",
                Priority = Priority.Low
            },
            new TodoDto()
            {
                Id = 2,
                Title = "Ta oppvasken",
                DueDate = DateTime.Today,
            },
            new TodoDto()
            {
                Id = 3,
                Title = "Handle matvarer",
                Description = "Ost, Skinke, Kjøkkenpapir"
            },
            new TodoDto()
            {
                Id = 4,
                Title = "Hente pakke",
                IsDone = true
            }
        };
    }
    
}