using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.CreateRule
{

    public class CreateRuleUseCase : IRequestHandler<CreateRuleRequest, int>
    {
        private readonly IRepository<Rule> _ruleRepository;

        public CreateRuleUseCase(IRepository<Rule> ruleRepository)
        {
            _ruleRepository = ruleRepository;
        }

        public async Task<int> Handle(CreateRuleRequest request, CancellationToken cancellationToken)
        {
            var rule = new Rule
            {
                Name = request.Name,
                Description = request.Description,
                // TODO Need to add to join table for this condition to allow multiple conditions
                //ConditionId = request.ConditionId,
            };
            await _ruleRepository.AddAsync(rule);
            return rule.Id;
        }
    }

    public class CreateRuleRequest : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<int> ConditionIds { get; set; }
        // TODO Need to add to join table for this condition to allow multiple conditions
        // public int ConditionId { get; set; }
        public int RewardId { get; set; }
    }
}