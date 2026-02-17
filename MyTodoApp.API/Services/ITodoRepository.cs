using MyTodoApp.API.Entities;

namespace MyTodoApp.API.Services;

public interface ITodoRepository
{
    Task<IEnumerable<Todo>> GetTodosAsync();
    Task<Todo?> GetTodoAsync(int id, bool includeTasks);
    Task<IEnumerable<TodoTask>> GetTodoTaskForTodoAsync(int todoId);
    Task<TodoTask?> GetTodoTaskAsync(int todoId, int taskId);
}