using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.GetAllRules
{

    public class GetAllRulesUseCase : IRequestHandler<GetAllRulesQuery, GetAllRulesResponse>
    {
        private readonly IRepository<Rule> _RuleRepository;

        public GetAllRulesUseCase(IRepository<Rule> ruleRepository)
        {
            _RuleRepository = ruleRepository;
        }

        public async Task<GetAllRulesResponse> Handle(GetAllRulesQuery request, CancellationToken cancellationToken)
        {
            List<Rule> getAllRules = (List<Rule>)await _RuleRepository.GetAllAsync();
            return new GetAllRulesResponse(getAllRules);
        }
    }



}