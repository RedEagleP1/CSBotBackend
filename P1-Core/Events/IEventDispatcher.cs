namespace P1_Core.Events
{
    public interface IEventDispatcher<T> where T : BaseEvent
    {
        //TODO should probably be async and use Task
        void Dispatch(IEnumerable<T> events);
    }
}