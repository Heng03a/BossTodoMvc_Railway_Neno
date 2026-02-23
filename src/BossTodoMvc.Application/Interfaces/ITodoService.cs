using BossTodoMvc.Domain.Entities;

namespace BossTodoMvc.Application.Interfaces
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetFilteredAsync(string? status, string? sort);

        Task AddAsync(string title);

        Task ToggleCompleteAsync(int id);

        Task<TodoItem?> GetByIdAsync(int id);

        Task UpdateAsync(int id, string title);

        Task DeleteAsync(int id);
    }
}
