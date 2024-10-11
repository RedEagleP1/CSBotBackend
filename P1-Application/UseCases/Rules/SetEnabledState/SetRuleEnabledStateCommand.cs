using MediatR;

namespace P1_Application.UseCases.Rules.SetRuleEnabledState
{
    public class SetRuleEnabledStateCommand : IRequest
    {
        public int RuleId { get; set; }
        public bool EnabledState { get; set; }
    }
}