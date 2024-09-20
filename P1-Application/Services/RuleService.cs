using P1_Core.Entities;

namespace P1_Application.Services
{

    public class RuleService
    {
        public bool EvaluateConditions(ICollection<Condition> conditions)
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

        public void ApplyRewards(ICollection<Reward> rewards, User user)
        {
            foreach (var reward in rewards)
            {
                reward.Apply(user);
            }
        }
    }
}