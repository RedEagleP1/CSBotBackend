using MediatR;

namespace P1_Application.UseCases.Rules.AddConditionToRule
{
    public class AddConditionToRuleCommand : IRequest
    {
        public int RuleId { get; set; }
        public int ConditionId { get; set; }
    }
}