namespace P1_Core.Entities
{
    public class Result : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        
        public ICollection<ItemResult> ItemResults { get; set; }
        public virtual ICollection<Rule>? Rules { get; set; }

    }
}