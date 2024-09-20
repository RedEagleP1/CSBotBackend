using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.GetAllRules
{

    public class GetAllRulesUseCase : IRequestHandler<GetAllRulesRequest, List<Rule>>
    {
        private readonly IRepository<Rule> _RuleRepository;
        private readonly IMediator _mediator;

        public GetAllRulesUseCase(IMediator mediator, IRepository<Rule> RuleRepository)
        {
            _RuleRepository = RuleRepository;
            _mediator = mediator;
        }

        public async Task<List<Rule>> Handle(GetAllRulesRequest request, CancellationToken cancellationToken)
        {
            List<Rule> getAllRules = (List<Rule>)await _RuleRepository.GetAllAsync();
            await _mediator.Send(getAllRules, cancellationToken);
            return getAllRules;
        }
    }

    public class GetAllRulesRequest : IRequest<List<Rule>>
    {

    }
}