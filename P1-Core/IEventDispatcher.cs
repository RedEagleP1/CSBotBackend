namespace P1_Core
{
    public interface IEventDispatcher<TEvent> where TEvent : BaseEvent
    {
        Task DispatchEventsAsync(TEvent eventToDispatch);
    }
}