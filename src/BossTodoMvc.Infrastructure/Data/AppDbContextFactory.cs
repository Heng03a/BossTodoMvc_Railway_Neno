using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BossTodoMvc.Infrastructure.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseNpgsql(
         "Host=ep-dark-cake-a168liak.ap-southeast-1.aws.neon.tech;" +
    "Port=5432;" +
    "Database=neondb;" +
    "Username=neondb_owner;" +
    "Password=npg_vLKEwya1Uo5s;" +
    "SSL Mode=Require"
    );

        return new AppDbContext(optionsBuilder.Options);
    }
}
