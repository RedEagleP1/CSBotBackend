
using P1_Core.Entities;

namespace P1_Core.Interfaces
{
    public interface IConditionService
    {
        bool EvaluateCondition(Condition condition, object target);
    }
}