public interface ICondition<T>
{
    bool Evaluate(T context);
}
