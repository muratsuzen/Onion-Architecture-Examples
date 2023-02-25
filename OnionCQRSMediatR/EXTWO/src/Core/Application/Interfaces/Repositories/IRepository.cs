using Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);  
        Task<T> UpdateAsync(T entity);

        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllAsync(
            Expression<Func<T,bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
            Func<IQueryable<T>, IIncludableQueryable<T,object>>? include = null,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);
    }
}
