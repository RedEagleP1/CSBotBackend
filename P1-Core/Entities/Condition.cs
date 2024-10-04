using System.ComponentModel.DataAnnotations;

namespace P1_Core.Interfaces
{

    public class Condition : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Rule>? Rules { get; set; }

        public string Operation { get; set; }
        public string ExpectedValue { get; set; }
        public string ExpectedResult { get; set; }
    }
}