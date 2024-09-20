using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.UpdateRule
{

    public class UpdateRuleUseCase : IRequestHandler<UpdateRuleRequest, int>
    {
        private readonly IRepository<Rule> _RuleRepository;
        private readonly IMediator _mediator;

        public UpdateRuleUseCase(IMediator mediator, IRepository<Rule> RuleRepository)
        {
            _RuleRepository = RuleRepository;
            _mediator = mediator;
        }

        public async Task<int> Handle(UpdateRuleRequest request, CancellationToken cancellationToken)
        {
            await _RuleRepository.UpdateAsync(request.Rule);
            //await _mediator.Send(updateEntity, cancellationToken);
            return request.Rule.Id;
        }
    }

    public class UpdateRuleRequest : IRequest<int>
    {
        public Rule Rule { get; set; }
    }
}