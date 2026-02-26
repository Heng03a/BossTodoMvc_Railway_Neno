using BossTodoMvc.Application.Interfaces;
using BossTodoMvc.Domain.Entities;
using BossTodoMvc.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BossTodoMvc.Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
        return await _context.TodoItems.ToListAsync();
    }

    public async Task<TodoItem?> GetByIdAsync(int id)
    {
        return await _context.TodoItems.FindAsync(id);
    }

    public async Task AddAsync(TodoItem item)
    {
        await _context.TodoItems.AddAsync(item);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

public void Remove(TodoItem item)
{
    _context.TodoItems.Remove(item);
}

}
