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
            // Added below line on 25/2/2026 - After at powershell -->switch to psql CLI -
            //                               - at psql CLI, created own database and own scheme, 
            //                               - refer KH Phua Notes - ChatGPT Logs and Powershell Logs 
            //                               - VVIP VKIV - 20260225T04_16am - BossTodoMvc - Setup for Neon Console PostgreSQL (Railway related too)  - One-Time manual migration 
             modelBuilder.HasDefaultSchema("app");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>(entity =>
            {
                // Phua amended below on 25/2/2026 - use and specify Path "app"
                entity.ToTable("todo_items", "app"); // 🔒 physical table name
                //entity.ToTable("todo_items"); // 🔒 physical table name
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone"); // 🔒 UTC-safe
            });
        }
    }
}
