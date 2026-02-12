using Microsoft.AspNetCore.Mvc;

namespace MyTodoApp.API.Controllers;

[ApiController]
[Route("api/todo")]
public class TaskController : ControllerBase
{
    
    [HttpGet]
    public ActionResult<IEnumerable<TaskDto>> GetTodos()
    {
        List<TaskDto> todoItems = TodoDataStore.Instance.Todos;
        return Ok(todoItems);
    }

    [HttpGet("{id}")]
    public ActionResult<TaskDto> GetTodo(int id)
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