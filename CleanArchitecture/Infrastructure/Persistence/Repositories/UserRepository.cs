using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Linq;

namespace Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext)
        {

        }

        Task<User> IUserRepository.GetByEmail(string email, CancellationToken cancellationToken)
        {
            return dbContext.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
    }
}
