namespace P1_Application.Boundaries
{
    //TODO we may want to use the IHttpContextAccessor to get the user id in the event we don't need to track user id from the bot
    // We will need an implementation to cover both the UI and the bot
    public class ApplicationContext
    {
        public int UserId { get; set; }
    }
}