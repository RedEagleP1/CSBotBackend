using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.EvaluateRule
{
    public class EvaluateRuleUseCase : IRequestHandler<EvaluateRuleCommand, EvaluateRuleResponse>
    {
        private readonly IRepository<Rule> _RuleRepository;


        public EvaluateRuleUseCase(IRepository<Rule> ruleRepository)
        {
            _RuleRepository = ruleRepository;
        }

        public async Task<EvaluateRuleResponse> Handle(EvaluateRuleCommand request, CancellationToken cancellationToken)
        {
            // Find the rule.
            //var rule = query.Queryable.Include(r => r.Conditions).Include(r => r.Results).FirstOrDefault(r => r.Id == ruleId);
            var rule = await _RuleRepository.GetByIdAsync(request.RuleId);
            if (rule == null)
                return new EvaluateRuleResponse(null);

            // ruleservice.EvaluateConditions(rule.Conditions);
            // if true ruleservice.ApplyRewards(rule.Rewards, user);

            return new EvaluateRuleResponse(rule);
        }

    }


}