using Microsoft.Extensions.Logging;

namespace P1_Application.Exceptions
{
    public class P1Exception : Exception
    {
        private ILogger _logger;

        public P1Exception(ILogger logger, string message) : base(message)
        {
            _logger = logger;
            logger.LogError(message);
        }
    }
}