using Microsoft.AspNetCore.Mvc;
using MyTodoApp.API.Services;

namespace MyTodoApp.API.Controllers;

[ApiController]
[Route("api/todos")]
public class TodoController : ControllerBase
{

    private readonly ILogger<TodoController> _logger;
    private readonly IMailService _mailService;

    public TodoController(ILogger<TodoController> logger, IMailService mailService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
    }
    
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
            _logger.LogInformation($"Todo item with id {id} not found.");
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

    [HttpPut("{id}")]
    public ActionResult UpdateTodo(int id, [FromBody] TodoDto todoDto)
    {
        if (!TodoDataStore.Instance.Todos.Exists(t => t.Id == id))
        {
            return NotFound();
        }
        
        //todo
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteTodo(int id)
    {
        TodoDto? todoItem = TodoDataStore.Instance.Todos
            .FirstOrDefault(t => t.Id == id);
        
        if (todoItem == null)
        {
            return NotFound();
        }

        TodoDataStore.Instance.Todos.Remove(todoItem);
        _mailService.SendMail("Todo item deleted", $"The todo item with id {id} has been deleted.");
        return NoContent();
    }
    
}