using Application.Features.Products.Dtos;
using MediatR;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductDto>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
    }
}
