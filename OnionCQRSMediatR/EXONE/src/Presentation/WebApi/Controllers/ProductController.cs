using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetProductListQuery getProductListQuery = new GetProductListQuery();
            var productListModel = await mediator.Send(getProductListQuery);
            return Ok(productListModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand createProductCommand)
        {
            var result = await mediator.Send(createProductCommand);
            return Ok(result);
        }
    }
}
