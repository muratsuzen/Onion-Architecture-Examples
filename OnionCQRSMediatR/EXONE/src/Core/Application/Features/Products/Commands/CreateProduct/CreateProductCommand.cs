using Application.Features.Products.Dtos;
using Application.Pipelines.Authorization;
using Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductDto>,ISecuredRequest, ICacheRemoveRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }

        public string CacheKey => "Product";

        public string[] Roles => new[] { "Admin" };
    }
}
