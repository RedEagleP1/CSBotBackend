
// Implementation classes
using P1_Application.Services.RulesEngine;
namespace P1_Application.Services.RulesEngine
{
    public class Rule<TTrigger, TContext, TResponse> : IRule<TTrigger, TContext, TResponse>
    {
        public required string Name { get; init; }
        public string? Description { get; init; }
        public required ITrigger<TTrigger> Trigger { get; init; }
        public required ICondition<TContext> Condition { get; init; }
        public required IResponse<TResponse> Response { get; init; }
    }
}
