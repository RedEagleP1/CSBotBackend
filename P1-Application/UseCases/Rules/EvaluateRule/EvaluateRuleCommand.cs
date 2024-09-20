using MediatR;

namespace P1_Application.UseCases.Rules.EvaluateRule
{
    public class EvaluateRuleCommand : IRequest<EvaluateRuleResponse>
    {
        public int UserId { get; set; }
        public int RuleId { get; set; }
    }
}