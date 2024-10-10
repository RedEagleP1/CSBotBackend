
namespace P1_Application.Services.RulesEngine
{
    public class ConditionFactory<TCondition>
    {
        private readonly Dictionary<string, Func<Dictionary<string, object>, ICondition<TCondition>>> _triggerBuilders = new();

        public void RegisterTriggerBuilder(string type, Func<Dictionary<string, object>, ICondition<TCondition>> builder)
        {
            _triggerBuilders[type] = builder;
        }

        public ICondition<TCondition> CreateConditionFromRecord(ConditionRecord record)
        {
            if (!_triggerBuilders.TryGetValue(record.Type, out var builder))
            {
                throw new InvalidOperationException($"No builder registered for trigger type: {record.Type}");
            }
            return builder(record.Parameters);
        }
    }
}
