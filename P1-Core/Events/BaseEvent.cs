namespace P1_Core.Events
{
    public abstract class BaseEvent
    {
        protected BaseEvent() => OccuredOn = DateTime.UtcNow;
        public DateTime OccuredOn { get; }
    }
}