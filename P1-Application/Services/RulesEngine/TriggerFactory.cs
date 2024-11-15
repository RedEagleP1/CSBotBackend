
namespace P1_Application.Services.RulesEngine
{
    // Factory classes
    public class TriggerFactory<TTrigger>
    {
        private readonly Dictionary<string, Func<Dictionary<string, object>, ITrigger<TTrigger>>> _triggerBuilders = new();

        public void RegisterTriggerBuilder(string type, Func<Dictionary<string, object>, ITrigger<TTrigger>> builder)
        {
            _triggerBuilders[type] = builder;
        }

        public ITrigger<TTrigger> CreateTriggerFromRecord(TriggerRecord record)
        {
            if (!_triggerBuilders.TryGetValue(record.Type, out var builder))
            {
                throw new InvalidOperationException($"No builder registered for trigger type: {record.Type}");
            }
            return builder(record.Parameters);
        }
    }
}
