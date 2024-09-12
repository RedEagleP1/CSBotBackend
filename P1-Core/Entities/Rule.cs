using System.ComponentModel.DataAnnotations;
using P1_Core.Entities.Interfaces;

namespace P1_Core.Entities
{
    public class Rule
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public int ConditionRuleId {get;set;}
        public int RewardId {get;set;}
        public int ChannelId {get;set;}
        public List<Condition> Conditions { get; set; }
        public virtual Reward Reward { get; set; }
        public virtual Channel Channel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    
}