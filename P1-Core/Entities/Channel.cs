using System.ComponentModel.DataAnnotations.Schema;

namespace P1_Core.Entities {
    public class Channel {
        public int Id { get; set; }
        //TODO is there a channel Id or type, some descriminant value to use?
        public string Name { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<Condition> Conditions { get; set; }
        public virtual ICollection<Reward> Rewards { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}