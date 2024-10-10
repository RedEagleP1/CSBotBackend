public class AlwaysTrueCondition<T> : ICondition<T>
{
    public bool Evaluate(T context) => true;
}
