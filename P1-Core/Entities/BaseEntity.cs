using System.ComponentModel.DataAnnotations;

namespace P1_Core.Entities
{
    public abstract class BaseEntity {
        [Key]
        public int Id {get;set;}
    }
}