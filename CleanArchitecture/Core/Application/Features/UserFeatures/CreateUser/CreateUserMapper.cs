using AutoMapper;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Features.UserFeatures.CreateUser
{
    public sealed class CreateUserMapper : Profile
    {
        public CreateUserMapper()
        {
            CreateMap<CreateUserRequest, User>().ReverseMap();
            CreateMap<CreateUserResponse, User>().ReverseMap();
        }
    }
}
