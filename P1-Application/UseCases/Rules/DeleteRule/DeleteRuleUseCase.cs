using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.DeleteRule
{
    public class DeleteRuleUseCase : IRequestHandler<DeleteRuleCommand, DeleteRuleResponse>
    {
        private readonly IRepository<Rule> _RuleRepository;

        public DeleteRuleUseCase(IRepository<Rule> ruleRepository)
        {
            _RuleRepository = ruleRepository;
        }

        public async Task<DeleteRuleResponse> Handle(DeleteRuleCommand request, CancellationToken cancellationToken)
        {
            DeleteOneEntityRequest<Rule> deleteRequest = new DeleteOneEntityRequest<Rule>(new Rule
            {
                Id = request.Id,
            });

            DeleteOneEntityResponse<Rule> response = new DeleteEntityUseCase<Rule>(_RuleRepository).Handle(deleteRequest, cancellationToken).Result;

            return new DeleteRuleResponse(deleteRequest.Entity);
        }

    }


}