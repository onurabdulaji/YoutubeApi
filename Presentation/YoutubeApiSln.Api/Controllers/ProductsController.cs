using MediatR;
using Microsoft.AspNetCore.Mvc;
using YoutubeApiSln.Application.Features.Products.Queries.GetAllProducts;

namespace YoutubeApiSln.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var response = await mediator.Send(new GetAllProductsQueryRequest());
        return Ok(response);
    }
}
