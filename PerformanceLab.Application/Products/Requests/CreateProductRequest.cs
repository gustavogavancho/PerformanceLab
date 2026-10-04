namespace PerformanceLab.Application.Products.Requests;

public sealed record CreateProductRequest(
    string Name,
    string? Description,
    decimal Price,
    int Stock);