using Castle.Core.Logging;

namespace P1_Application
{
    public class P1Exception : Exception
    {
        public P1Exception(ILogger logger, string message) : base(message)
        {
            logger.Error(message);
        }
    }
}