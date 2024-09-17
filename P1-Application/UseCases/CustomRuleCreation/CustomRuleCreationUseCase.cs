using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.CustomRuleCreation
{
    public class CustomRuleCreationUseCase : IRequestHandler<CreateRuleCommand, int>
    {
        private readonly IRepository<Rule> _ruleRepository;
        public CustomRuleCreationUseCase(IRepository<Rule> ruleRepository)
        {
            _ruleRepository = ruleRepository;
        }
        public async Task<int> Handle(CreateRuleCommand request, CancellationToken cancellationToken)
        {

            var rule = new Rule
            {
                Name = request.Name,
                Description = request.Description
            };
            await _ruleRepository.AddAsync(rule);
            return rule.Id;

        }

    }


    public class CreateRuleCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ChannelId { get; set; }
        public int ActionId { get; set; }
        // TODO Need to add to join table for this condition to allow multiple conditions
        // public int ConditionId { get; set; }
        public int RewardId { get; set; }
    }
}