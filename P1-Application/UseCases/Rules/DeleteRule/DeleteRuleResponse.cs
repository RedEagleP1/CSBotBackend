using MediatR;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.DeleteRule
{
    public class DeleteRuleResponse : IRequest
    {
        public Rule Rule { get; set; }

        public DeleteConditionResponse(Rule rule)
        {
            Rule = rule;
        }
    }
}