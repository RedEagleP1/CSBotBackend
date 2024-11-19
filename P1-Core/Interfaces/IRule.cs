namespace P1_Core.Interfaces
{
    // Core interfaces
    public interface IRule<TTrigger, TCondition, TResult>
    {
        string Name { get; }
        string? Description { get; }
        ITrigger<TTrigger> Trigger { get; }
        ICondition<TCondition> Condition { get; }
        IResult<TResult> Result { get; }
    }
}
