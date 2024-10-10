public class RuleFactory<TTrigger, TContext, TResponse>
{
    private readonly TriggerFactory<TTrigger> _triggerFactory;
    private readonly ResponseFactory<TResponse> _responseFactory;
    private readonly IDatabase _database;

    public RuleFactory(
        TriggerFactory<TTrigger> triggerFactory,
        ResponseFactory<TResponse> responseFactory,
        IDatabase database)
    {
        _triggerFactory = triggerFactory;
        _responseFactory = responseFactory;
        _database = database;
    }

    public async Task<IRule<TTrigger, TContext, TResponse>> CreateRuleAsync(RuleRecord ruleRecord)
    {
        var triggerRecord = await _database.GetTriggerByIdAsync(ruleRecord.TriggerId);
        var responseRecord = await _database.GetResponseByIdAsync(ruleRecord.ResponseId);

        var trigger = _triggerFactory.CreateTriggerFromRecord(triggerRecord);
        var response = _responseFactory.CreateResponseFromRecord(responseRecord);

        return new Rule<TTrigger, TContext, TResponse>
        {
            Name = ruleRecord.Name,
            Description = ruleRecord.Description,
            Trigger = trigger,
            Condition = new AlwaysTrueCondition<TContext>(), //TODO implement condition factory
            Response = response
        };
    }
}
