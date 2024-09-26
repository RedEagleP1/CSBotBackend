using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Application.Services;
using P1_Core;
using P1_Core.Entities;
using P1_Core.Services;
using P1_Application.Exceptions;

namespace P1_Application.UseCases.Rules.EvaluateRule
{
    public class EvaluateRulesUseCase : IRequestHandler<EvaluateRuleCommand>
    {
        private readonly IRepository<Rule> _RuleRepository;
        private readonly RuleService _RuleService;
        private readonly ConditionService _ConditionService;
        private readonly IRepository<User> _UserRepository;

        public EvaluateRulesUseCase(IRepository<Rule> ruleRepository, RuleService ruleService, ConditionService conditionService, IRepository<User> userRepositor)
        {
            _RuleRepository = ruleRepository;
            _RuleService = ruleService;
            _ConditionService = conditionService;
            _UserRepository = userRepositor;
        }

        public async Task Handle(EvaluateRuleCommand request, CancellationToken cancellationToken)
        {
            // Find the rule.
            var rules = GetRules(request.RuleId);
            if (rules.Count == 0) throw new P1Exception("Rule not found");
            // evaluate the rule
            var user = await _UserRepository.GetByIdAsync(request.UserId);
            _RuleService.EvaluateRule(request.)
            // ApplyRewards(user, rules);
            await _UserRepository.UpdateAsync(user);
        }

        private async ApplyRewards(User user, Rule rule)
        {
            foreach (Condition condition)
        }

        private IList<Rule> GetRules(IEnumerable<int> ruleIds)
        {
            return _RuleRepository.Query()
            .Include(r => r.Conditions)
            .Where(r => ruleIds.Contains(r.Id))
            .ToList();
        }
    }
}