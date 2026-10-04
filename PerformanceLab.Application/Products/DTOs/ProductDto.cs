namespace PerformanceLab.Application.Products.DTOs;

public sealed record ProductDto(
    int Id,
    string Name,
    string? Description,
    decimal Price,
    int Stock,
    DateTime CreatedAt);