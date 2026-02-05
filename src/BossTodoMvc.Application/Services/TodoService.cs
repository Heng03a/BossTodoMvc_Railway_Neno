using BossTodoMvc.Application.Interfaces;
using BossTodoMvc.Domain.Entities;

namespace BossTodoMvc.Application.Services;

public class TodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    //public async Task<List<TodoItem>> GetAllAsync()
    //{
    //    return await _repository.GetAllAsync();
    //}

    public async Task<List<TodoItem>> GetFilteredAsync(string status, string sort)
    {
        var items = await _repository.GetAllAsync();

        items = status switch
        {
            "active" => items.Where(t => !t.IsCompleted).ToList(),
            "completed" => items.Where(t => t.IsCompleted).ToList(),
            _ => items
        };

        items = sort == "oldest"
            ? items.OrderBy(t => t.CreatedAt).ToList()
            : items.OrderByDescending(t => t.CreatedAt).ToList();

        return items;
    }

    public async Task AddAsync(string title)
    {
        var todo = new TodoItem(title);
        await _repository.AddAsync(todo);
        await _repository.SaveChangesAsync();
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
