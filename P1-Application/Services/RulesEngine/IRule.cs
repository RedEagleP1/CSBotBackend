namespace P1_Application.Services.RulesEngine
{
    // Core interfaces
    public interface IRule<TTrigger, TContext, TResponse>
    {
        string Name { get; }
        string? Description { get; }
        ITrigger<TTrigger> Trigger { get; }
        ICondition<TContext> Condition { get; }
        IResponse<TResponse> Response { get; }
    }
}
