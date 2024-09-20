using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Application.Services;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.EvaluateRule
{
    public class EvaluateRuleUseCase : IRequestHandler<EvaluateRuleCommand>
    {
        private readonly IRepository<Rule> _RuleRepository;
        private readonly RuleService _RuleService;


        public EvaluateRuleUseCase(IRepository<Rule> ruleRepository, RuleService ruleservice)
        {
            _RuleRepository = ruleRepository;
            _RuleService = ruleservice;
        }

        public async Task Handle(EvaluateRuleCommand request, CancellationToken cancellationToken)
        {
            var query = _RuleRepository.Query();
            // Find the rule.
            var rules = GetRules(request.RuleId);
            // var rule = await _RuleRepository.GetByIdAsync(request.RuleId);
            foreach (var rule in rules)
            {
                var success = _RuleService.EvaluateConditions(rule.Conditions);
                if (!success) return;
            }

            //todo apply rewards and save the data
            // if true ruleservice.ApplyRewards(rule.Rewards, user);


        }

        private IList<Rule> GetRules(IEnumerable<int> ruleIds)
        {
            return _RuleRepository.Query().Include(r => r.Conditions).Include(r => r.Rewards).Where(r => ruleIds.Contains(r.Id)).ToList();
        }

    }


}