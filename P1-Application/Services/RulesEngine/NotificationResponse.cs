public class NotificationResponse : IResponse<string>
{
    private readonly string _message;

    public NotificationResponse(string message)
    {
        _message = message;
    }

    public string Execute() => _message;
}
