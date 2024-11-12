using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;
using P1_Core.Entities;
using Microsoft.Extensions.Logging;

namespace P1_Application.UseCases.Rules.SetRuleEnabledState
{
    public class SetRuleEnabledStateUseCase : IRequestHandler<SetRuleEnabledStateCommand>
    {
        private readonly IRepository<Rule> _RuleRepository;
        private readonly IRepository<Condition> _ConditionRepository;
        private readonly ILogger _Logger;


        public SetRuleEnabledStateUseCase(IRepository<Rule> ruleRepository, IRepository<Condition> conditionRepository, ILogger logger)
        {
            _RuleRepository = ruleRepository;
            _ConditionRepository = conditionRepository;
            _Logger = logger;
        }

        public async Task Handle(SetRuleEnabledStateCommand request, CancellationToken cancellationToken)
        {
            // Find the rule and the condition to add.
            var rule = await _RuleRepository.GetByIdAsync(request.RuleId);
            if (rule == null) throw new P1Exception(_Logger, $"Rule with id {request.RuleId} not found");


            // Add the condition to the rule
            rule.IsEnabled = request.EnabledState;

            // Save the changes
            await _RuleRepository.UpdateAsync(rule);
        }

    }
}