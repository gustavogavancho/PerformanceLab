using PerformanceLab.Domain.Entities;

namespace PerformanceLab.Application.Abstractions.Persistence;

public interface IProductRepository
{
    Task<IReadOnlyCollection<Product>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task AddAsync(Product product, CancellationToken cancellationToken = default);

    void Remove(Product product);
}