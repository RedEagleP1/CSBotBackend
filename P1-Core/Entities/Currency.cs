namespace P1_Core.Entities
{
    public class Currency : BaseEntity
    {
        public int Id { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public string Name {get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}