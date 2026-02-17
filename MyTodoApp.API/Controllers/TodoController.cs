using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTodoApp.API.Entities;
using MyTodoApp.API.Models;
using MyTodoApp.API.Services;

namespace MyTodoApp.API.Controllers;

[ApiController]
[Route("api/todos")]
public class TodoController : ControllerBase
{

    private readonly ILogger<TodoController> _logger;
    private readonly IMailService _mailService;
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public TodoController(ILogger<TodoController> logger, IMailService mailService, ITodoRepository todoRepository, IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoWithoutTasksDto>>> GetTodos()
    {
        IEnumerable<Todo> todoItems = await _todoRepository.GetTodosAsync();
        return Ok(_mapper.Map<IEnumerable<TodoWithoutTasksDto>>(todoItems));
    }

    [HttpGet("{id}")]
    public ActionResult<Todo> GetTodo(int id)
    {
        TodoDto? todoItem = _todoDataStore.Todos
            .FirstOrDefault(t => t.Id == id);

        if (todoItem == null)
        {
            _logger.LogInformation($"Todo item with id {id} not found.");
            return NotFound();
        }
        
        return Ok(todoItem);
    }

    [HttpPost]
    public ActionResult<Todo> CreateTodo([FromBody] TodoDto todoDto)
    {
        if (_todoDataStore.Todos.Exists(todo => todo.Id == todoDto.Id))
        {
            return Conflict();
        }
        
        _todoDataStore.Todos.Add(todoDto);
        
        return CreatedAtAction(
            nameof(GetTodo),
            new { id = todoDto.Id },
            todoDto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateTodo(int id, [FromBody] TodoDto todoDto)
    {
        if (!_todoDataStore.Todos.Exists(t => t.Id == id))
        {
            return NotFound();
        }
        
        //todo
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteTodo(int id)
    {
        TodoDto? todoItem = _todoDataStore.Todos
            .FirstOrDefault(t => t.Id == id);
        
        if (todoItem == null)
        {
            return NotFound();
        }

        _todoDataStore.Todos.Remove(todoItem);
        _mailService.SendMail("Todo item deleted", $"The todo item with id {id} has been deleted.");
        return NoContent();
    }
    
}