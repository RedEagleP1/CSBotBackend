namespace P1_Core.Entities {
    public class Trigger : BaseEntity {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public virtual ICollection<Rule> Rules { get; set; }
    }
}