using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.AddTriggerToRule
{
    public class AddTriggerToRuleUseCase : IRequestHandler<AddTriggerToRuleCommand>
    {
        private readonly IRepository<Rule> _RuleRepository;
        private readonly IRepository<Trigger> _TriggerRepository;
        private readonly ILogger _Logger;


        public AddTriggerToRuleUseCase(IRepository<Rule> ruleRepository, IRepository<Trigger> triggerRepository, ILogger logger)
        {
            _RuleRepository = ruleRepository;
            _TriggerRepository = triggerRepository;
            _Logger = logger;
        }

        public async Task Handle(AddTriggerToRuleCommand request, CancellationToken cancellationToken)
        {
            // Find the rule and the condition to add.
            var rule = await _RuleRepository.GetByIdAsync(request.RuleId);
            if (rule == null) throw new P1Exception(_Logger, $"Rule with id {request.RuleId} not found");

            var trigger = await _TriggerRepository.GetByIdAsync(request.TriggerId);
            if (trigger == null) throw new P1Exception(_Logger, $"Trigger with id {request.TriggerId} not found");

            if (!rule.Triggers.Contains(trigger)) throw new P1Exception(_Logger, $"Rule with id {request.RuleId} already contains trigger with id {request.TriggerId} not found");


            // Add the condition to the rule
            rule.Triggers.Add(trigger);

            // Save the changes
            await _RuleRepository.UpdateAsync(rule);
        }

    }
}