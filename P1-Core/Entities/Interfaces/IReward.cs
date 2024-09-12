namespace P1_Core.Entities.Interfaces
{
    public interface IReward
    {
        // TODO see if this should only apply to users vs other entities
        void Apply(User user);
    }
}