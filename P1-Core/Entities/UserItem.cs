using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P1_Core.Entities
{
    
    public class UserItem : BaseEntity
    {

        public int UserId { get; set; }

        public int ItemId { get; set; }

        [ForeignKey("DiscordUserId")]
        public virtual DiscordUser User { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        public int Quantity { get; set; }

        // Hiding the inherited Id property so that we can use the UserId and ItemId as the composite key
        [NotMapped]
        public new int Id { get; set; }
    }
}