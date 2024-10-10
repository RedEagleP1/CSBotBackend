using P1_Application.Services.RulesEngine;
using P1_Core.Entities;
using P1_Core.Interfaces;
namespace P1_Application.Services.RulesEngine
{
    public class RuleFactory<TTrigger, TCondition, TResponse>
    {
        private readonly TriggerFactory<TTrigger> _triggerFactory;
        private readonly ResponseFactory<TResponse> _responseFactory;
        private readonly ConditionFactory<TCondition> _conditionFactory;

        private readonly IRepository<Trigger> _triggerRepository;
        private readonly IRepository<Result> _responseRepository;
        private readonly IRepository<Condition> _conditionRepository;


        public RuleFactory(
            TriggerFactory<TTrigger> triggerFactory,
            ResponseFactory<TResponse> responseFactory,
            ConditionFactory<TCondition> conditionFactory,
            
            IRepository<Trigger> triggerRepository,
            IRepository<Result> responseRepository,
            IRepository<Condition> conditionRepository)
        {
            _triggerFactory = triggerFactory;
            _responseFactory = responseFactory;
            _conditionFactory = conditionFactory;
            
            _triggerRepository = triggerRepository;
            _responseRepository = responseRepository;
            _conditionRepository = conditionRepository;
        }
        // TODO implement conversion from RuleRecord to Rule, ConditionRecord to Condition, etc
        // TODO use generic builder for factories
        public async Task<IRule<TTrigger, TCondition, TResponse>> CreateRuleAsync(RuleRecord ruleRecord)
        {
            var triggerEntity = await _triggerRepository.GetByIdAsync(ruleRecord.TriggerId);
            var responseEntity = await _responseRepository.GetByIdAsync(ruleRecord.ResponseId);
            var conditionEntity = await _conditionRepository.GetByIdAsync(ruleRecord.ConditionId);

            var triggerRecord = new TriggerRecord();
            var responseRecord = new ResponseRecord();
            var conditionRecord = new ConditionRecord();

            var trigger = _triggerFactory.CreateTriggerFromRecord(triggerRecord);
            var response = _responseFactory.CreateResponseFromRecord(responseRecord);
            var condition = _conditionFactory.CreateConditionFromRecord(conditionRecord);

            return new Rule<TTrigger, TCondition, TResponse>
            {
                Name = ruleRecord.Name,
                Description = ruleRecord.Description,
                Trigger = trigger,
                Condition = condition, 
                Response = response
            };
        }
    }
}