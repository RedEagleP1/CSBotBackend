using MediatR;

namespace P1_Application.UseCases.Rules.EvaluateRule
{
    public class EvaluateRuleCommand : IRequest
    {
        public int UserId { get; set; }
        public IEnumerable<int> RuleIds { get; set; }
    }
}