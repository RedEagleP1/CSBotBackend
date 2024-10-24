using System.ComponentModel.DataAnnotations.Schema;

namespace P1_Core.Entities.JoinTables
{

    public class TriggerRule : BaseEntity
    {
        [ForeignKey("TriggerId")]
        public int TriggerId { get; set; }
        [ForeignKey("RuleId")]
        public int RuleId { get; set; }

        [NotMapped]
        public new int Id { get; set; }
    }
}