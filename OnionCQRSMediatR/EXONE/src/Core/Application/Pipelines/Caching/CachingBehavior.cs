using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pipelines.Caching
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ICachableRequest
    {
        private readonly IDistributedCache cache;
        private readonly ILogger<CachingBehavior<TRequest, TResponse>> logger;
        private readonly CacheSettings cacheSettings;

        public CachingBehavior(ILogger<CachingBehavior<TRequest, TResponse>> logger, IDistributedCache cache, CacheSettings cacheSettings)
        {
            this.logger = logger;
            this.cache = cache;
            this.cacheSettings = cacheSettings;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
