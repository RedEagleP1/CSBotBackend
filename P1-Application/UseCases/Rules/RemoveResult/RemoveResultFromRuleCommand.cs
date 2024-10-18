using MediatR;

namespace P1_Application.UseCases.Rules.RemoveResultFromRule
{
    public class RemoveResultFromRuleCommand : IRequest
    {
        public int RuleId { get; set; }
        public int ResultId { get; set; }
    }
}