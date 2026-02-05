using BossTodoMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BossTodoMvc.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
}
