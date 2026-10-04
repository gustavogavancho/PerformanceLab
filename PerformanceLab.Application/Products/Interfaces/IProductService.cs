using PerformanceLab.Application.Products.DTOs;
using PerformanceLab.Application.Products.Requests;

namespace PerformanceLab.Application.Products.Interfaces;

public interface IProductService
{
    Task<IReadOnlyCollection<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<ProductDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<ProductDto> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(int id, UpdateProductRequest request, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}