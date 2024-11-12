using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;
using P1_Core.Entities.JoinTables;
using ILogger = Serilog.ILogger;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.RemoveTriggerFromRule
{
    public class RemoveTriggerFromRuleUseCase : IRequestHandler<RemoveTriggerFromRuleCommand>
    {
        private readonly IRepository<TriggerRule> _TriggerRuleRepository;
        private readonly ILogger _Logger;


        public RemoveTriggerFromRuleUseCase(IRepository<TriggerRule> triggerRuleRepository, ILogger logger)
        {
            _TriggerRuleRepository = triggerRuleRepository;
            _Logger = logger;
        }

        public async Task Handle(RemoveTriggerFromRuleCommand request, CancellationToken cancellationToken)
        {
            await _TriggerRuleRepository.DeleteAsync(new TriggerRule { RuleId = request.RuleId, TriggerId = request.TriggerId });

        }

    }
}