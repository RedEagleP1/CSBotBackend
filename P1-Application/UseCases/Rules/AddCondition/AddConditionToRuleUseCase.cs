using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.AddConditionToRule
{
    public class AddConditionToRuleUseCase : IRequestHandler<AddConditionToRuleCommand>
    {
        private readonly IRepository<Rule> _RuleRepository;
        private readonly IRepository<Condition> _ConditionRepository;
        private readonly ILogger _Logger;


        public AddConditionToRuleUseCase(IRepository<Rule> ruleRepository, IRepository<Condition> conditionRepository, ILogger logger)
        {
            _RuleRepository = ruleRepository;
            _ConditionRepository = conditionRepository;
            _Logger = logger;
        }

        public async Task Handle(AddConditionToRuleCommand request, CancellationToken cancellationToken)
        {
            // Find the rule and the condition to add.
            var rule = await _RuleRepository.GetByIdAsync(request.RuleId);
            if (rule == null) throw new P1Exception(_Logger, $"Rule with id {request.RuleId} not found");

            var condition = await _ConditionRepository.GetByIdAsync(request.ConditionId);
            if (condition == null) throw new P1Exception(_Logger, $"Condition with id {request.ConditionId} not found");


            // Add the condition to the rule
            rule.Conditions.Add(condition);

            // Save the changes
            await _RuleRepository.UpdateAsync(rule);
        }

    }
}