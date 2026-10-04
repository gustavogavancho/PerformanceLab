using Microsoft.EntityFrameworkCore;
using PerformanceLab.Application.Abstractions.Persistence;
using PerformanceLab.Domain.Entities;
using PerformanceLab.Persistence.SqlServer.Context;

namespace PerformanceLab.Persistence.SqlServer.Repositories;

internal sealed class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task<IReadOnlyCollection<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Products.AsNoTracking()
            .OrderBy(product => product.Id)
            .ToArrayAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Products.FirstOrDefaultAsync(product => product.Id == id, cancellationToken);
    }

    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await context.Products.AddAsync(product, cancellationToken);
    }

    public void Remove(Product product)
    {
        context.Products.Remove(product);
    }
}