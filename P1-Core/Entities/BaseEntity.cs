using System.ComponentModel.DataAnnotations;

namespace P1_Core.Entities
{
    public abstract class BaseEntity {
        [Key]
        public int Id {get;set;}
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
    }
}