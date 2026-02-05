using BossTodoMvc.Domain.Entities;

namespace BossTodoMvc.Application.Interfaces;

public interface ITodoRepository
{
    Task<List<TodoItem>> GetAllAsync();
    Task<TodoItem?> GetByIdAsync(int id);
    Task AddAsync(TodoItem item);
    Task SaveChangesAsync();
    void Remove(TodoItem item);

}
