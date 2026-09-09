namespace MyStore.Application.DTOs
{
    public record ProductDTO(int ProductId, string SKU, string Name, int Stock, decimal Price, string SourceImage);

    public record CreateProductDTO( string SKU, string Name, int Stock, decimal Price, Stream? ImageStream, string? ImageFileName);

    public record UpdateProductDTO(int ProductId, string SKU, string Name, int Stock, decimal Price, Stream? ImageStream, string? ImageFileName);
}
