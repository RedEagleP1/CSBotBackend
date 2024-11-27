using MediatR;
using P1_Core.Interfaces;
using P1_Core.Entities.JoinTables;
using Microsoft.Extensions.Logging;

namespace P1_Application.UseCases.Rules.AddConditionToRule
{
    public class AddConditionToRuleUseCase : IRequestHandler<AddConditionToRuleCommand>
    {
        private readonly IRepository<ConditionRule> _ConditionRuleRepository;


        public AddConditionToRuleUseCase(IRepository<ConditionRule> conditionRuleRepository)
        {
            _ConditionRuleRepository = conditionRuleRepository;
        }

        public async Task Handle(AddConditionToRuleCommand request, CancellationToken cancellationToken)
        {
            await _ConditionRuleRepository.AddAsync(new ConditionRule { RuleId = request.RuleId, ConditionId = request.ConditionId });
        }

    }
}