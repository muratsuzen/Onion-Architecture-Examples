using AutoMapper;
using MediatR;
using ProductApp.Application.Interfaces.Repostiory;
using ProductApp.Application.Wrappers;
using ProductApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }

        class CreateProductCommandHandle : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {

            IProductRepository productRepository;
            IMapper mapper;

            public CreateProductCommandHandle(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = mapper.Map<Product>(request);
                await productRepository.AddAsync(product);

                return new ServiceResponse<Guid>(product.Id);
            }
        }
    }
}
