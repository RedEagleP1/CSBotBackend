using P1_Core.Entities;

namespace P1_Application.Services
{

    public class RuleService
    {
        public bool EvaluateConditions(IList<Condition> conditions)
        {

            foreach (var condition in conditions)
            {
                if (condition.IsSatisfied())
                {
                    return true;
                }
            }
            return false;
        }

        public void ApplyRewards(IList<Reward> rewards, User user)
        {
            foreach (var reward in rewards)
            {
                reward.Apply(user);
            }
        }
    }
}