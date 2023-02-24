using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Application.Pipelines.Caching
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ICachableRequest
    {
        private readonly IDistributedCache cache;
        private readonly ILogger<CachingBehavior<TRequest, TResponse>> logger;

        public CachingBehavior(ILogger<CachingBehavior<TRequest, TResponse>> logger, IDistributedCache cache)
        {
            this.logger = logger;
            this.cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = request.GetType();
            logger.LogInformation("{Request} is configured for caching", requestName);

            TResponse response;
            byte[]? cacheResponse = await cache.GetAsync(request.CacheKey, cancellationToken);
            if (cacheResponse != null)
            {
                response = JsonSerializer.Deserialize<TResponse>(Encoding.Default.GetString(cacheResponse));
                logger.LogInformation("Returning cached value for {Request}", requestName);
                return response;
            }

            logger.LogInformation($"{requestName} Cache Key: {request.CacheKey} is not inside the cache, executing request.");
            response = await next();
            byte[] serializeData = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response));
            await cache.SetAsync(request.CacheKey, serializeData);
            return response;
        }
    }
}
