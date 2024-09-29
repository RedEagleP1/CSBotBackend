using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Entities;
using P1_Core.Services;
using P1_Application.Exceptions;
using Microsoft.Extensions.Logging;

namespace P1_Application.UseCases.Rules.EvaluateRule
{
    public class EvaluateRuleUseCase : IRequestHandler<EvaluateRuleCommand>
    {
        private readonly IRepository<Rule> _RuleRepository;
        private readonly RuleService _RuleService;
        private readonly ResultService _ResultService;
        private readonly IRepository<User> _UserRepository;
        private readonly ILogger _Logger;


        public EvaluateRuleUseCase(IRepository<Rule> ruleRepository, RuleService ruleService, ResultService resultService, IRepository<User> userRepositor, ILogger logger)
        {
            _RuleRepository = ruleRepository;
            _RuleService = ruleService;
            _ResultService = resultService;
            _UserRepository = userRepositor;
            _Logger = logger;
        }

        public async Task Handle(EvaluateRuleCommand request, CancellationToken cancellationToken)
        {
            var user = await _UserRepository.GetByIdAsync(request.UserId);

            // Find the rule.
            var rules = GetRules(request.RuleId);
            if (rules.Count == 0) throw new P1Exception(_Logger, "Rule not found");

            // Evaluate the rule
            var rule = rules[0];
            if (rule.Results?.Count == 0)
                throw new P1Exception(_Logger, "Rule has no results.");

            if (_RuleService.EvaluateRule(rule, "target"))
            {
                //if true evaluate results and award items
                _ResultService.ApplyResults(user, rule.Results);
                await _UserRepository.UpdateAsync(user);
            }
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