using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures.CreateUser
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request);
            userRepository.Create(user);
            await unitOfWork.Save(cancellationToken);
            return mapper.Map<CreateUserResponse>(user);
        }
    }
}
