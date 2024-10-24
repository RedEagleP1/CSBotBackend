using System.ComponentModel.DataAnnotations.Schema;

namespace P1_Core.Entities.JoinTables
{

    public class ResultRule : BaseEntity
    {
        [ForeignKey("ResultId")]
        public int ResultId { get; set; }
        [ForeignKey("RuleId")]
        public int RuleId { get; set; }

        [NotMapped]
        public new int Id { get; set; }
    }
}