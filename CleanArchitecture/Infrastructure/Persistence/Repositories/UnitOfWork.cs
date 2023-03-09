using Application.Repositories;
using Persistence.Context;
using System;
using System.Linq;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly DataContext dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Task Save(CancellationToken cancellationToken)
        {
            return dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
