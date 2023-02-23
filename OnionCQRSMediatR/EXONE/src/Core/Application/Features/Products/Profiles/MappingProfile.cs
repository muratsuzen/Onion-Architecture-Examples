using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Dtos;
using Application.Features.Products.Queries.GetProductList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();

            CreateMap<Product,GetProductListDto>().ReverseMap();
            CreateMap<Product, GetProductListQuery>().ReverseMap();
        }
    }
}
