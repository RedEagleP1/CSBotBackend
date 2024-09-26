using P1_Core.Entities;

namespace P1_Core.Services
{
    public class RuleService
    {
        private readonly ConditionService _conditionService;
        public RuleService(ConditionService conditionsService){
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