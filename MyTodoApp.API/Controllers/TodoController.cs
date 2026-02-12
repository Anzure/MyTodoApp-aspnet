using Microsoft.AspNetCore.Mvc;

namespace MyTodoApp.API.Controllers;

[ApiController]
[Route("api/todos")]
public class TodoController : ControllerBase
{
    
    [HttpGet]
    public ActionResult<IEnumerable<TodoDto>> GetTodos()
    {
        List<TodoDto> todoItems = TodoDataStore.Instance.Todos;
        return Ok(todoItems);
    }

    [HttpGet("{todoId}")]
    public ActionResult<TodoDto> GetTodo(int todoId)
    {
        TodoDto? todoItem = TodoDataStore.Instance.Todos
            .FirstOrDefault(t => t.Id == todoId);

        if (todoItem == null)
        {
            return NotFound("Todo item not found by ID: " + todoId);
        }
        
        return Ok(todoItem);
    }
    
}