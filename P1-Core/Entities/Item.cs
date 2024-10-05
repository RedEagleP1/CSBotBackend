using System.ComponentModel.DataAnnotations;

namespace P1_Core.Entities
{
    public class Item : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public ICollection<UserItem>? UserItems { get; set; }
    }
}