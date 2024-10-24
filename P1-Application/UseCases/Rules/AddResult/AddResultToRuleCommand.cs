using MediatR;

namespace P1_Application.UseCases.Rules.AddResultToRule
{
    public class AddResultToRuleCommand : IRequest
    {
        public int RuleId { get; set; }
        public int ResultId { get; set; }
    }
}