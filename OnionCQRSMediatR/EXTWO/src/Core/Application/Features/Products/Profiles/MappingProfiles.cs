using Application.Features.Products.Commands.CreateCommand;
using Application.Features.Products.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
        }
    }
}
