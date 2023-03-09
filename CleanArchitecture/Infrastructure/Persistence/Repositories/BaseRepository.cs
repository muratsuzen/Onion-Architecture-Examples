using Application.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext dbContext;

        public BaseRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(T entity)
        {
            dbContext.Add(entity);
        }

        public void Delete(T entity)
        {
            entity.DateDelete = DateTimeOffset.UtcNow;
            dbContext.Update(entity);
        }

        public Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public void Update(T entity)
        {
            dbContext.Update(entity);
        }
    }
}
