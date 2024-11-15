using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Rules.AddConditionToRule
{
    public class AddConditionToRuleUseCase : IRequestHandler<AddConditionToRuleCommand>
    {
        private readonly IRepository<ConditionRule> _ConditionRuleRepository;
        private readonly ILogger _Logger;


        public AddConditionToRuleUseCase(IRepository<ConditionRule> conditionRuleRepository, ILogger logger)
        {
            _ConditionRuleRepository = conditionRuleRepository;
            _Logger = logger;
        }

        public async Task Handle(AddConditionToRuleCommand request, CancellationToken cancellationToken)
        {
            await _ConditionRuleRepository.AddAsync(new ConditionRule { RuleId = request.RuleId, ConditionId = request.ConditionId });
        }

    }
}