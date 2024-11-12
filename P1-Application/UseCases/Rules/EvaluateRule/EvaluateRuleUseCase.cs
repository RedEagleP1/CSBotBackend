using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Application.Services;
using P1_Core;
using P1_Core.Entities;
using P1_Application.Exceptions;

namespace P1_Application.UseCases.Rules.EvaluateRule
{
    public class EvaluateRuleUseCase : IRequestHandler<EvaluateRuleCommand>
    {
        private readonly IRepository<Rule> _RuleRepository;
        private readonly RuleService _RuleService;
        private readonly IRepository<User> _UserRepository;

        public EvaluateRuleUseCase(IRepository<Rule> ruleRepository, IRepository<User> userRepositor)
        {
            _RuleRepository = ruleRepository;
            // _RuleService = ruleservice;
            _UserRepository = userRepositor;
        }

        public async Task Handle(EvaluateRuleCommand request, CancellationToken cancellationToken)
        {
            // Find the rule.
            var rules = GetRules(request.RuleId);
            if (rules.Count == 0) throw new P1Exception("Rule not found");

            var user = await _UserRepository.GetByIdAsync(request.UserId);
            // ApplyRewards(user, rules);
            await _UserRepository.UpdateAsync(user);
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