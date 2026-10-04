using Microsoft.EntityFrameworkCore;
using PerformanceLab.Application.Abstractions.Persistence;
using PerformanceLab.Domain.Entities;

namespace PerformanceLab.Persistence.SqlServer.Context;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}