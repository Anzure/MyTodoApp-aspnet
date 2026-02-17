using Microsoft.EntityFrameworkCore;
using MyTodoApp.API.DbContext;
using MyTodoApp.API.Entities;

namespace MyTodoApp.API.Services;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDataContext _context;
    
    public TodoRepository(TodoDataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<Todo>> GetTodosAsync()
    {
        return await _context.Todos.OrderBy(t => t.Title).ToListAsync();
    }

    public async Task<Todo?> GetTodoAsync(int id, bool includeTasks)
    {
        return includeTasks ?
            await _context.Todos
                .Include(t => t.Tasks)
                .FirstOrDefaultAsync(t => t.Id == id) : 
            await _context.Todos
                .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<TodoTask>> GetTodoTaskForTodoAsync(int todoId)
    {
        return await _context.Tasks
            .Where(t => t.TodoId == todoId)
            .ToListAsync();
    }

    public async Task<TodoTask?> GetTodoTaskAsync(int todoId, int taskId)
    {
        return await _context.Tasks
            .Where(t => t.Id == taskId && t.Id == todoId)
            .FirstOrDefaultAsync();
    }
    
}