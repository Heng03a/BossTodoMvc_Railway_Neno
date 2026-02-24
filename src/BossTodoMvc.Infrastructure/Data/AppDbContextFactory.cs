using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BossTodoMvc.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString =
                "Host=ep-dark-cake-a168liak.ap-southeast-1.aws.neon.tech;" +
                "Port=5432;" +
                "Database=neondb;" +
                "Username=neondb_owner;" +
                "Password=npg_Zvj4Y9xVSoCi;" +
                "SSL Mode=Require;" +
                "Trust Server Certificate=true";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseNpgsql(connectionString,
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "app"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
