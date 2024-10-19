using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Rules.AddTriggerToRule
{
    public class AddTriggerToRuleUseCase : IRequestHandler<AddTriggerToRuleCommand>
    {
        private readonly IRepository<TriggerRule> _TriggerRuleRepository;
        private readonly ILogger _Logger;


        public AddTriggerToRuleUseCase(IRepository<TriggerRule> triggerRuleRepository, ILogger logger)
        {
            _TriggerRuleRepository = triggerRuleRepository;
            _Logger = logger;
        }

        public async Task Handle(AddTriggerToRuleCommand request, CancellationToken cancellationToken)
        {
            await _TriggerRuleRepository.AddAsync(new TriggerRule { RuleId = request.RuleId, TriggerId = request.TriggerId });
        }

    }
}