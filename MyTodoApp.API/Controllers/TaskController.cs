using Microsoft.AspNetCore.Mvc;
using MyTodoApp.API.Models;

namespace MyTodoApp.API.Controllers;

[ApiController]
[Route("api/todos/{todoId}/tasks")]
public class TaskController : Controller
{
    
    private readonly ILogger<TaskController> _logger;
    [Obsolete("Will be removed when repository is implemented.")]
    private readonly TodoDataStore _todoDataStore;

    public TaskController(ILogger<TaskController> logger, TodoDataStore todoDataStore)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _todoDataStore = todoDataStore ?? throw new ArgumentNullException(nameof(todoDataStore));
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<TaskDto>> GetTasks(int todoId)
    {
        // Find todo item
        TodoDto? todoItem = _todoDataStore.Todos
            .FirstOrDefault(todo => todo.Id == todoId);

        if (todoItem == null)
        {
            return NotFound();
        }

        // Return tasks
        ICollection<TaskDto> todoTasks = todoItem.Tasks;
        return Ok(todoTasks);
    }

    [HttpGet("{taskId}")]
    public ActionResult<TaskDto> GetTask(int todoId, int taskId)
    {
        // Find todo item
        TodoDto? todoItem = _todoDataStore.Todos
            .FirstOrDefault(todo => todo.Id == todoId);

        if (todoItem == null)
        {
            return NotFound();
        }
        
        // Find and return task
        TaskDto? taskDto = todoItem.Tasks
            .FirstOrDefault(t => t.Id == taskId);

        if (taskDto == null)
        {
            return NotFound();
        }
        
        return Ok(taskDto);
    }
    
}