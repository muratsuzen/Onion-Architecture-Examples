using MediatR;
using System;
using System.Linq;

namespace Application.Features.UserFeatures.CreateUser
{
    public sealed record CreateUserRequest(string Email, string Name) : IRequest<CreateUserResponse>;
}
