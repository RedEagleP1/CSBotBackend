using MediatR;

namespace P1_Application.UseCases.Rules.RemoveTriggerFromRule
{
    public class RemoveTriggerFromRuleCommand : IRequest
    {
        public int RuleId { get; set; }
        public int TriggerId { get; set; }
    }
}