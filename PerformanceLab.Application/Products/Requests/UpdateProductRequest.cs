namespace PerformanceLab.Application.Products.Requests;

public sealed record UpdateProductRequest(
    string Name,
    string? Description,
    decimal Price,
    int Stock);