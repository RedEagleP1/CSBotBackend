public class WeatherRuleSystem
{
    private readonly TriggerFactory<WeatherEvent> _triggerFactory = new();
    private readonly ResponseFactory<string> _responseFactory = new();
    private readonly RuleFactory<WeatherEvent, object, string> _ruleFactory;
    private readonly RuleEngine<WeatherEvent, object, string> _ruleEngine = new();
    private readonly IDatabase _database;

    public WeatherRuleSystem(IDatabase database)
    {
        _database = database;
        _ruleFactory = new RuleFactory<WeatherEvent, object, string>(_triggerFactory, _responseFactory, database);
        RegisterBuilders();
    }

    private void RegisterBuilders()
    {
        _triggerFactory.RegisterTriggerBuilder("RAIN", parameters =>
            new RainTrigger());

        _triggerFactory.RegisterTriggerBuilder("TEMPERATURE", parameters =>
            new TemperatureTrigger(
                Convert.ToDouble(parameters.GetValueOrDefault("threshold", 30.0))));

        _responseFactory.RegisterResponseBuilder("NOTIFICATION", parameters =>
            new NotificationResponse(
                parameters.GetValueOrDefault("message", "").ToString() ?? ""));
    }

    public async Task LoadRulesFromDatabaseAsync()
    {
        var ruleRecords = await _database.GetAllRulesAsync();
        foreach (var record in ruleRecords)
        {
            var rule = await _ruleFactory.CreateRuleAsync(record);
            _ruleEngine.AddRule(rule);
        }
    }

    public IEnumerable<string> ProcessWeatherEvent(WeatherEvent weatherEvent)
    {
        return _ruleEngine.ProcessEvent(weatherEvent, new object());
    }
}
