using Application.Features.Products.Dtos;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<GetProductListDto>>
    {
        IProductRepository productRepository;
        IMapper mapper;

        public GetProductListQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<List<GetProductListDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();
            var mappedProducts = mapper.Map<List<GetProductListDto>>(products);
            return mappedProducts;
        }
    }
}
