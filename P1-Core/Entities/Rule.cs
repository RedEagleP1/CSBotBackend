using System.ComponentModel.DataAnnotations;
using P1_Core.Entities.Interfaces;

namespace P1_Core.Entities
{
    public class Rule : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public virtual ICollection<Condition> Conditions { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    
}