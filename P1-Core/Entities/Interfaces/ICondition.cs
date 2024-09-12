namespace P1_Core.Entities.Interfaces
{
    public interface ICondition
    {
        bool IsSatisfied(User user, Action action, Channel channel);
    }
}