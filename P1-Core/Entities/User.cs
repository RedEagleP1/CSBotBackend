namespace P1_Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public ulong DiscordId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Currency> Currencies { get; set; }
        public virtual ICollection<UserCurrency> UserCurrencies { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        

    }
    
}