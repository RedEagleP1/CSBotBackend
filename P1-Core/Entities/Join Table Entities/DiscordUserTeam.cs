using System.ComponentModel.DataAnnotations.Schema;

namespace P1_Core.Entities.JoinTables
{

    public class DiscordUserTeam : BaseEntity
    {
        [ForeignKey("TeamId")]
        public int TeamId { get; set; }
        [ForeignKey("DiscordUserId")]
        public int DiscordUserId { get; set; }

        [NotMapped]
        public new int Id { get; set; }
    }
}