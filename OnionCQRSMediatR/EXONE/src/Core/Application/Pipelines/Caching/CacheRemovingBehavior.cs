using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace Application.Pipelines.Caching
{
    public class CacheRemovingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ICacheRemoveRequest
    {
        private readonly IDistributedCache cache;
        private readonly ILogger<CacheRemovingBehavior<TRequest, TResponse>> logger;

        public CacheRemovingBehavior(IDistributedCache cache, ILogger<CacheRemovingBehavior<TRequest, TResponse>> logger)
        {
            this.cache = cache;
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = request.GetType();
            logger.LogInformation("{Request} is configured for cache removing", requestName);

            TResponse response;
            response = await next();
            await cache.RemoveAsync(request.CacheKey, cancellationToken);
            logger.LogInformation("{Request} removed cache.", requestName);
            return response;
        }
    }
}
