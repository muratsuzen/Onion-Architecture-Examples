using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        ILogger<TRequest> logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string requestName = $"{request.GetType().Name} [{Guid.NewGuid()}]";

            logger.LogInformation($"[START] {requestName}");

            var stopwatch = Stopwatch.StartNew();

            try
            {
                LogRequest(request, requestName);
                return await next();
            }
            finally
            {
                stopwatch.Stop();
                logger.LogInformation($"[END] {requestName} Execution time={stopwatch.ElapsedMilliseconds}ms");
            }
        }
        void LogRequest(TRequest request, string requestName)
        {
            try
            {
                logger.LogInformation($"[PROPS] {requestName} {JsonSerializer.Serialize(request)}");
            }
            catch (NotSupportedException)
            {
                logger.LogInformation($"[Serialization ERROR] {requestName} Could not serialize the request.");
            }
        }
    }
}
