using MediatR;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.EvaluateRule
{
    public class EvaluateRuleResponse : IRequest
    {
        public Rule Rule { get; }

        public EvaluateRuleResponse(Rule rule)
        {
            Rule = rule;
        }
    }
}