using MediatR;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.UpdateRule
{
    public class UpdateRuleResponse : IRequest
    {
        public Rule Rule { get; private set; }

        public UpdateRuleResponse(Rule rule)
        {
            Rule = rule;
        }
    }
}