using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.RemoveTriggerFromRule
{
    public class RemoveTriggerFromRuleUseCase : IRequestHandler<RemoveTriggerFromRuleCommand>
    {
        private readonly IRepository<Rule> _RuleRepository;
        private readonly IRepository<Trigger> _TriggerRepository;
        private readonly ILogger _Logger;


        public RemoveTriggerFromRuleUseCase(IRepository<Rule> ruleRepository, IRepository<Trigger> TriggerRepository, ILogger logger)
        {
            _RuleRepository = ruleRepository;
            _TriggerRepository = TriggerRepository;
            _Logger = logger;
        }

        public async Task Handle(RemoveTriggerFromRuleCommand request, CancellationToken cancellationToken)
        {
            // Find the rule and the trigger to add.
            var rule = await _RuleRepository.GetByIdAsync(request.RuleId);
            if (rule == null) throw new P1Exception(_Logger, $"Rule with id {request.RuleId} not found");

            var trigger = await _TriggerRepository.GetByIdAsync(request.TriggerId);
            if (trigger == null) throw new P1Exception(_Logger, $"Trigger with id {request.TriggerId} not found");


            // Remove the trigger from the rule
            rule.Triggers.Remove(trigger);

            // Save the changes
            await _RuleRepository.UpdateAsync(rule);
        }

    }
}