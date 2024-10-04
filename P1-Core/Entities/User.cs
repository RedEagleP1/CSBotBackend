namespace P1_Core.Interfaces
{
    public class User : BaseEntity
    {
        public ulong DiscordId { get; set; }
        public ICollection<UserItem>? UserItems { get; set; }
        public ICollection<UserMetaData>? UserMetaData { get; set; }

    }
}