using Microsoft.EntityFrameworkCore;
using poc.Infrastructure.Persistence.Configurations;

namespace poc.Infrastructure.Persistence;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AssemblyReference).Assembly,
            type =>
            {
                var value = typeof(IConfigurationsReference).Namespace;
                return value != null && type.Namespace != null &&
                       type.Namespace.StartsWith(value);
            });
    }
}