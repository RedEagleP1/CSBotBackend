using P1_Core.Events;


namespace P1_Core.Interfaces
{
    public interface IEventDispatcher<TEvent> where TEvent : BaseEvent
    {
        Task DispatchEventsAsync(TEvent eventToDispatch);
    }
}