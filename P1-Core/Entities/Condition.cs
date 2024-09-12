using P1_Core.Entities.Interfaces;

namespace P1_Core.Entities {

    public class Condition: ICondition 
    { 
        public int Id { get; set; }
        public Action Action { get; set; }
        public Channel Channel { get; set; }

        public bool IsSatisfied(User user, Action action, Channel channel)
        {
            //TODO imeplement this interface
            throw new NotImplementedException();
        }
    }
}