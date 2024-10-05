namespace P1_Core.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User>? TeamMembers { get; set; }
    }
}