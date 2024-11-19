namespace P1_Core.Interfaces
{
    public interface ICondition<T>
    {
        bool Evaluate(T context);
    }
}
