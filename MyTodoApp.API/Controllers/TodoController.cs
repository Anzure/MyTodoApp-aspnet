using Microsoft.AspNetCore.Mvc;

namespace MyTodoApp.API.Controllers;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    
    [HttpGet]
    public ActionResult<IEnumerable<TodoDto>> GetTodos()
    {
        List<TodoDto> todoItems = TodoDataStore.Instance.Todos;
        return Ok(todoItems);
    }

    [HttpGet("{id}")]
    public ActionResult<TodoDto> GetTodo(int id)
    {
        var todoItem = TodoDataStore.Instance.Todos
            .FirstOrDefault(t => t.Id == id);

        if (todoItem == null)
        {
            return NotFound();
        }
        
        return Ok(todoItem);
    }
    
}