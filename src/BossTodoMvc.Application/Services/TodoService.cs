using BossTodoMvc.Application.Interfaces;
using BossTodoMvc.Domain.Entities;

namespace BossTodoMvc.Application.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

public async Task<List<TodoItem>> GetFilteredAsync(string? status, string? sort)
    {
        var items = await _repository.GetAllAsync();

        // FILTER
        if (status == "active")
        {
            items = items.Where(t => !t.IsCompleted).ToList();
        }
        else if (status == "completed")
        {
            items = items.Where(t => t.IsCompleted).ToList();
        }

        // SORT
        if (sort == "oldest")
        {
            items = items.OrderBy(t => t.CreatedAt).ToList();
        }
        else if (sort == "completed")
        {
            items = items
                .OrderByDescending(t => t.IsCompleted)
                .ThenByDescending(t => t.CreatedAt)
                .ToList();
        }
        else if (sort == "active")
        {
            items = items
                .OrderBy(t => t.IsCompleted)
                .ThenByDescending(t => t.CreatedAt)
                .ToList();
        }
        else
        {
            // newest (default)
            items = items.OrderByDescending(t => t.CreatedAt).ToList();
        }

        return items; // ✅ guaranteed return
    }    
   public async Task AddAsync(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return;

        var todo = new TodoItem(title);
        await _repository.AddAsync(todo);
    }

    public async Task ToggleCompleteAsync(int id)
    {
        var todo = await _repository.GetByIdAsync(id);
        if (todo == null) return;

        todo.ToggleComplete();
        await _repository.SaveChangesAsync();
    }

    public async Task<TodoItem?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(int id, string title)
    {
        var todo = await _repository.GetByIdAsync(id);
        if (todo == null) return;

        todo.UpdateTitle(title);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var todo = await _repository.GetByIdAsync(id);
        if (todo == null) return;

        _repository.Remove(todo);
        await _repository.SaveChangesAsync();
    }
}