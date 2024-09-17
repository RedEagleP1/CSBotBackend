using System.ComponentModel.DataAnnotations.Schema;
using P1_Core.Entities.Interfaces;

namespace P1_Core.Entities
{
    [Table("Rewards")]
    public class Reward : IReward
    {
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void Apply(User user)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}