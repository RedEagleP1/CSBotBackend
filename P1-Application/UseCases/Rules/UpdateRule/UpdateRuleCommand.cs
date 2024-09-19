using MediatR;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.UpdateRule
{
    public class UpdateRuleCommand : IRequest<UpdateRuleResponse>
    {
        public Rule Rule { get; set; }
    }
}