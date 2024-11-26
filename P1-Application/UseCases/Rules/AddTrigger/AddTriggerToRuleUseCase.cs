using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Application.Exceptions;
using P1_Core.Entities.JoinTables;
using Microsoft.Extensions.Logging;

namespace P1_Application.UseCases.Rules.AddTriggerToRule
{
    public class AddTriggerToRuleUseCase : IRequestHandler<AddTriggerToRuleCommand>
    {
        private readonly IRepository<TriggerRule> _TriggerRuleRepository;


        public AddTriggerToRuleUseCase(IRepository<TriggerRule> triggerRuleRepository)
        {
            _TriggerRuleRepository = triggerRuleRepository;
        }

        public async Task Handle(AddTriggerToRuleCommand request, CancellationToken cancellationToken)
        {
            await _TriggerRuleRepository.AddAsync(new TriggerRule { RuleId = request.RuleId, TriggerId = request.TriggerId });
        }

    }
}