namespace P1_Core.Entities
{
    public class User : BaseEntity
    {
        public ulong DiscordId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
    
}