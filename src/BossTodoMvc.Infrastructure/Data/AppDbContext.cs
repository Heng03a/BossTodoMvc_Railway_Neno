using BossTodoMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BossTodoMvc.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.ToTable("todo_items"); // 🔒 physical table name
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone"); // 🔒 UTC-safe
            });
        }
    }
}
