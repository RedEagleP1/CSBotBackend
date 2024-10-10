using MediatR;

namespace P1_Application.UseCases.Rules.RemoveConditionFromRule
{
    public class RemoveConditionFromRuleCommand : IRequest
    {
        public int RuleId { get; set; }
        public int ConditionId { get; set; }
    }
}