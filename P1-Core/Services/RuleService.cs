using P1_Core.Interfaces;

namespace P1_Core.Services
{
    public class RuleService : IRuleService
    {
        private readonly IConditionService _conditionService;
        public RuleService(IConditionService conditionsService)
        {
            _conditionService = conditionsService;
        }
        public bool EvaluateRule(Rule rule, object target)
        {
            foreach (Condition condition in rule.Conditions)
            {
                if (!_conditionService.EvaluateCondition(condition, target))
                    return false;
            }

            return true;
        }

    }
}