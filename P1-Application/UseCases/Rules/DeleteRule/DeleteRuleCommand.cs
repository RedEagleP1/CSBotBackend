using MediatR;

namespace P1_Application.UseCases.Rules.DeleteRule
{
    public class DeleteRuleCommand : IRequest<DeleteRuleResponse>
    {
        public int Id { get; set; }
    }
}