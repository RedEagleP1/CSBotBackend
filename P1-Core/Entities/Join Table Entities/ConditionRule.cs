using System.ComponentModel.DataAnnotations.Schema;

namespace P1_Core.Entities.JoinTables
{

    public class ConditionRule : BaseEntity
    {

        [ForeignKey("ConditionId")]
        public int ConditionId { get; set; }
        [ForeignKey("RuleId")]
        public int RuleId { get; set; }

        [NotMapped]
        public new int Id { get; set; }
    }
}