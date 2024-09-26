namespace P1_Core.Entities
{
    public class Result : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Value { get; set; }
        public virtual ICollection<Rule>? Rules { get; set; }
        
    }
}