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

    [HttpGet("{id}")]
    public ActionResult<TodoDto> GetTodo(int id)
    {
        TodoDto? todoItem = TodoDataStore.Instance.Todos
            .FirstOrDefault(t => t.Id == id);

        if (todoItem == null)
        {
            return NotFound();
        }
        
        return Ok(todoItem);
    }

    [HttpPost]
    public ActionResult<TodoDto> CreateTodo([FromBody] TodoDto todoDto)
    {
        if (TodoDataStore.Instance.Todos.Exists(todo => todo.Id == todoDto.Id))
        {
            return Conflict();
        }
        
        TodoDataStore.Instance.Todos.Add(todoDto);
        
        return CreatedAtAction(
            nameof(GetTodo),
            new { id = todoDto.Id },
            todoDto);
    }
    
}