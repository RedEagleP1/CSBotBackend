using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Rules.RemoveConditionFromRule
{
    public class RemoveConditionFromRuleUseCase : IRequestHandler<RemoveConditionFromRuleCommand>
    {
        private readonly IRepository<ConditionRule> _ConditionRuleRepository;
        private readonly ILogger _Logger;


        public RemoveConditionFromRuleUseCase(IRepository<ConditionRule> conditionRuleRepository, ILogger logger)
        {
            _ConditionRuleRepository = conditionRuleRepository;
            _Logger = logger;
        }

        public async Task Handle(RemoveConditionFromRuleCommand request, CancellationToken cancellationToken)
        {
            await _ConditionRuleRepository.DeleteAsync(new ConditionRule { RuleId = request.RuleId, ConditionId = request.ConditionId });
        }

    }
}