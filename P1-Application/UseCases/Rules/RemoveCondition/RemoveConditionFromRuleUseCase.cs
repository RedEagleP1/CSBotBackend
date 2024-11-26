using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core.Interfaces;
using P1_Application.Exceptions;
using P1_Core.Entities.JoinTables;
using Microsoft.Extensions.Logging;

namespace P1_Application.UseCases.Rules.RemoveConditionFromRule
{
    public class RemoveConditionFromRuleUseCase : IRequestHandler<RemoveConditionFromRuleCommand>
    {
        private readonly IRepository<ConditionRule> _ConditionRuleRepository;


        public RemoveConditionFromRuleUseCase(IRepository<ConditionRule> conditionRuleRepository)
        {
            _ConditionRuleRepository = conditionRuleRepository;
        }

        public async Task Handle(RemoveConditionFromRuleCommand request, CancellationToken cancellationToken)
        {
            await _ConditionRuleRepository.DeleteAsync(new ConditionRule { RuleId = request.RuleId, ConditionId = request.ConditionId });
        }

    }
}