using PerformanceLab.Application.Abstractions.Persistence;
using PerformanceLab.Application.Products.DTOs;
using PerformanceLab.Application.Products.Interfaces;
using PerformanceLab.Application.Products.Requests;
using PerformanceLab.Domain.Entities;

namespace PerformanceLab.Application.Products.Services;

public sealed class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductService
{
    public async Task<IReadOnlyCollection<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IReadOnlyCollection<Product> products = await productRepository.GetAllAsync(cancellationToken);

        return products.Select(Map)
            .ToArray();
    }

    public async Task<ProductDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        Product? product = await productRepository.GetByIdAsync(id, cancellationToken);

        return product is null
            ? null
            : Map(product);
    }

    public async Task<ProductDto> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
    {
        Product product = new(request.Name, request.Description, request.Price, request.Stock);

        await productRepository.AddAsync(product, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Map(product);
    }

    public async Task<bool> UpdateAsync(int id, UpdateProductRequest request, CancellationToken cancellationToken = default)
    {
        Product? product = await productRepository.GetByIdAsync(id, cancellationToken);

        if (product is null)
        {
            return false;
        }

        product.Update(
            request.Name,
            request.Description,
            request.Price,
            request.Stock);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        Product? product = await productRepository.GetByIdAsync(id, cancellationToken);

        if (product is null)
        {
            return false;
        }

        productRepository.Remove(product);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    private static ProductDto Map(Product product)
    {
        return new ProductDto(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Stock,
            product.CreatedAt);
    }
}