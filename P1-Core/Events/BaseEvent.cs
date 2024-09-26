namespace P1_Core
{
    public abstract class BaseEvent {
        protected BaseEvent() => OccuredOn = DateTime.UtcNow;
        public DateTime OccuredOn { get; }
    }
}