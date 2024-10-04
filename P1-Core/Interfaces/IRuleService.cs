
namespace P1_Core.Interfaces
{
    public interface IRuleService
    {
        bool EvaluateRule(Rule rule, object target);
    }
}