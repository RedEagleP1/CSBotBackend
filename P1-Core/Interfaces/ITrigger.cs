namespace P1_Core.Interfaces
{
    public interface ITrigger<T>
    {
        bool Check(T @event);
    }
}
