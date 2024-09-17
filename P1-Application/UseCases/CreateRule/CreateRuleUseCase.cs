using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.CreateRule
{

    public class CreateRuleUseCase : IRequestHandler<CreateRuleRequest, int>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Rule> _ruleRepository;

        public CreateRuleUseCase(IMediator mediator, IRepository<Rule> ruleRepository)
        {
            _mediator = mediator;
            _ruleRepository = ruleRepository;
        }

        public async Task<int> Handle(CreateRuleRequest request, CancellationToken cancellationToken)
        {
            var addRule = await _ruleRepository.AddAsync(request.Rule);
            await _mediator.Send(addRule, cancellationToken);
            return request.Rule.Id;
        }
    }

    public class CreateRuleRequest : IRequest<int>
    {
        public Rule Rule { get; set; }
    }
}