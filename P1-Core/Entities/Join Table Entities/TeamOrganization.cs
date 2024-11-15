using System.ComponentModel.DataAnnotations.Schema;

namespace P1_Core.Entities.JoinTables
{

    public class TeamOrganization : BaseEntity
    {
        [ForeignKey("OrganizationId")]
        public int OrganizationId { get; set; }
        [ForeignKey("TeamId")]
        public int TeamId { get; set; }

        [NotMapped]
        public new int Id { get; set; }
    }
}