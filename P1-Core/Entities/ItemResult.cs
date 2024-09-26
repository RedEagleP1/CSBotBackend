using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P1_Core.Entities
{
    public class ItemResult : BaseEntity
    {
        public int ItemId { get; set; }
        public int ResultId { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
        [ForeignKey("ResultId")]
        public virtual Result Result { get; set; }

        // This is so that we can define a composite key and hide the Id property from the base class
        [NotMapped]
        public new int Id { get; set; }
    }
}