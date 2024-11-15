using System.Diagnostics;
using System.Text.Json;
using MediatR;

namespace P1_Backend.MediatRPipeline
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<TRequest> _Logger;


        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _Logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = request?.GetType().Name;
            var requestGuid = Guid.NewGuid().ToString();

            var requestNameWithGuid = $"{requestName} [{requestGuid}]";

            try
            {
                _Logger.LogInformation($"[STARTING]: {requestNameWithGuid}  |  {JsonSerializer.Serialize(request)}");
            }
            catch (NotSupportedException e)
            {
                _Logger.LogInformation($"[ERROR]: {requestNameWithGuid}  |  Could not serialize the request: \"{e.Message}\"");
            }

            var stopWatch = Stopwatch.StartNew();

            TResponse response = await next();

            stopWatch.Stop();
            _Logger.LogInformation($"[FINISHED]: {requestNameWithGuid}  |  Execution time={stopWatch.ElapsedMilliseconds} ms");

            return response;
        }
    }
}