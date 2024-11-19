using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using P1_Core.Interfaces;
namespace P1_Application.RulesEngine
{
    // Rule engine
    public class RuleEngine<TTrigger, TContext, TResponse>
    {
        private readonly List<IRule<TTrigger, TContext, TResponse>> _rules = new();

        public void AddRule(IRule<TTrigger, TContext, TResponse> rule)
        {
            _rules.Add(rule);
        }

        public IEnumerable<TResponse> ProcessEvent(TTrigger @event, TContext context)
        {
            var responses = new List<TResponse>();

            foreach (var rule in _rules)
            {
                if (rule.Trigger.Check(@event) && rule.Condition.Evaluate(context))
                {
                    responses.Add(rule.Result.Execute());
                }
            }

            return responses;
        }
    }
}
