using Application.Features.Products.Dtos;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.CreateCommand
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDto>
    {
        IProductRepository productRepository;
        IMapper mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var mappedProduct = mapper.Map<Product>(request);
            var createdProduct = await productRepository.AddAsync(mappedProduct);
            var createdProductDto = mapper.Map<CreateProductDto>(createdProduct);
            return createdProductDto;
        }
    }
}
