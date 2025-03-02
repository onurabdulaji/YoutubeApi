using YoutubeApiSln.Application.DTOs;

namespace YoutubeApiSln.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryResponse
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public BrandDto? Brand { get; set; }
}
