using MediatR;

namespace P1_Application.UseCases.Rules.AddTriggerToRule
{
    public class AddTriggerToRuleCommand : IRequest
    {
        public int RuleId { get; set; }
        public int TriggerId { get; set; }
    }
}