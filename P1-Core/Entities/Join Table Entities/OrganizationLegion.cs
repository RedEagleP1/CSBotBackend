using System.ComponentModel.DataAnnotations.Schema;

namespace P1_Core.Entities.JoinTables
{
    public class OrganizationLegion : BaseEntity
    {
        [ForeignKey("LegionId")]
        public int LegionId { get; set; }

        [ForeignKey("OrganizationId")]
        public int OrganizationId { get; set; }

        [NotMapped]
        public new int Id { get; set; }
    }
}