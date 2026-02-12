using Microsoft.AspNetCore.Mvc;

namespace MyTodoApp.API.Controllers;

[ApiController]
[Route("api/todos/{todoId}/tasks")]
public class TaskController : Controller
{
    [HttpGet]
    public ActionResult<IEnumerable<TaskDto>> GetTasks(int todoId)
    {
        // Find todo item
        TodoDto? todoItem = TodoDataStore.Instance.Todos
            .FirstOrDefault(todo => todo.Id == todoId);

        if (todoItem == null)
        {
            return NotFound("Todo item not found by ID: " + todoId);
        }

        // Return tasks
        ICollection<TaskDto> todoTasks = todoItem.Tasks;
        return Ok(todoTasks);
    }

    [HttpGet("{taskId}")]
    public ActionResult<TaskDto> GetTask(int todoId, int taskId)
    {
        // Find todo item
        TodoDto? todoItem = TodoDataStore.Instance.Todos
            .FirstOrDefault(todo => todo.Id == todoId);

        if (todoItem == null)
        {
            return NotFound("Todo item not found by ID: " + todoId);
        }
        
        // Find and return task
        TaskDto? taskDto = todoItem.Tasks
            .FirstOrDefault(t => t.Id == taskId);

        if (taskDto == null)
        {
            return NotFound("Task not found by ID: " + taskId);
        }
        
        return Ok(taskDto);
    }
    
}