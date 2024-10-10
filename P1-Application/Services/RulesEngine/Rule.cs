
// Implementation classes
using P1_Application.Services.RulesEngine;
namespace P1_Application.Services.RulesEngine
{
    public class Rule<TTrigger, TCondition, TResult> : IRule<TTrigger, TCondition, TResult>
    {
        public required string Name { get; init; }
        public string? Description { get; init; }
        public required ITrigger<TTrigger> Trigger { get; init; }
        public required ICondition<TCondition> Condition { get; init; }
        public required IResult<TResult> Result { get; init; }
    }
}
