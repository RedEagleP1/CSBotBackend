using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.EvaluateRule
{

    public class EvaluateRuleUseCase : IRequestHandler<EvaluateRuleCommand, EvaluateRuleResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Rule> _ruleRepository;

        public EvaluateRuleUseCase(IMediator mediator, IRepository<Rule> ruleRepository)
        {
            _mediator = mediator;
            _ruleRepository = ruleRepository;
        }

        public async Task<EvaluateRuleResponse> Handle(EvaluateRuleCommand request, CancellationToken cancellationToken)
        {
            
            
            return rule.Id;
        }
    }

}