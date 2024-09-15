using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.DeleteRule
{
    public class DeleteRuleUseCase
    {
        private readonly IRepository<Rule> _RuleRepository;
        private readonly IMediator _mediator;

        public DeleteRuleUseCase(IMediator mediator, IRepository<Rule> RuleRepository)
        {
            _RuleRepository = RuleRepository;
            _mediator = mediator;
        }

        public async Task<int> Handle(DeleteRuleRequest request, CancellationToken cancellationToken)
        {
            var deleteRule = _RuleRepository.DeleteAsync(request.Id);
            return deleteRule.Id;
        }

        public class DeleteRuleRequest : IRequest<int>
        {
            public int Id { get; set; }
        }
    }
}