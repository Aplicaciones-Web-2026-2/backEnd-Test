using GreenTech.Test.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using GreenTech.Test.API.Shared.Infrastructure.Persistence.EFC.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace GreenTech.Test.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddInterceptors(new AuditableEntityInterceptor());
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.UseSnakeCaseNamingConvention();
    }
}