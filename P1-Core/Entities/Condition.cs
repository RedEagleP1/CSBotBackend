using P1_Core.Entities.Interfaces;

namespace P1_Core.Entities
{

    public class Condition : BaseEntity, ICondition
    {
        public int Id { get; set; }
        public virtual ICollection<Rule> Rules { get; set; }

        public bool IsSatisfied(User user, Action action)
        {
            //TODO imeplement this interface
            throw new NotImplementedException();
        }
    }
}