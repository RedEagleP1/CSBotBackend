using System.ComponentModel.DataAnnotations.Schema;

namespace P1_Core.Entities.JoinTables
{

    /// <summary>
    /// This entity represents a pairing between a game and a team in a join table.
    /// </summary>
    public class GameTeam : BaseEntity
    {

        [ForeignKey("TeamId")]
        public int TeamId { get; set; }
        [ForeignKey("GameId")]
        public int GameId { get; set; }

        [NotMapped]
        public new int Id { get; set; }
    }
}