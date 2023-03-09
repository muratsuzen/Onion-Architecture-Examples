using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.GetAllUser
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserRequest, List<GetAllUserResponse>>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetAllUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        async Task<List<GetAllUserResponse>> IRequestHandler<GetAllUserRequest, List<GetAllUserResponse>>.Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAll(cancellationToken);
            return mapper.Map<List<GetAllUserResponse>>(users);
        }
    }
}
