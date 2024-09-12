using P1_Core.Entities;

namespace P1_Core.Events
{
    public class CurrencyAddedEvent : BaseEvent
    {
        public CurrencyAddedEvent(User user, Currency currency, int amount)
        {
            User = user;
            Currency = currency;
            Amount = amount;
        }

        public User User { get; }
        public Currency Currency { get; }
        public int Amount { get; }
    }
    
}