namespace P1_Core.Entities
{
    public class UserCurrency
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Currency Currency { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}