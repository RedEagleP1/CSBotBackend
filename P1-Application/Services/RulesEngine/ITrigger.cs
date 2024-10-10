public interface ITrigger<T>
{
    bool Check(T @event);
}
