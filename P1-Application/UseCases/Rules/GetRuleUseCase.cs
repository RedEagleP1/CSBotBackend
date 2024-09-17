using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.GetRule
{

    public class GetRuleUseCase : IRequestHandler<GetRuleRequest, Rule>
    {
        private readonly IRepository<Rule> _RuleRepository;
        private readonly IMediator _mediator;

        public GetRuleUseCase(IMediator mediator, IRepository<Rule> RuleRepository)
        {
            _RuleRepository = RuleRepository;
            _mediator = mediator;
        }

        public async Task<Rule> Handle(GetRuleRequest request, CancellationToken cancellationToken)
        {
            Rule getRule = await _RuleRepository.GetByIdAsync(request.Id);
            await _mediator.Send(getRule, cancellationToken);
            return getRule;
        }
    }

    public class GetRuleRequest : IRequest<Rule>
    {
        public int Id { get; set; }
    }
}