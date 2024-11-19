using P1_Core.Interfaces;

namespace P1_Application.RulesEngine
{
    // TODO this needs to be replaced with a more generic response type
    public class NotificationResponse : IResult<string>
    {
        private readonly string _message;

        public NotificationResponse(string message)
        {
            _message = message;
        }

        public string Execute() => _message;
    }
}