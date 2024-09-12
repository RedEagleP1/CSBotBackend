using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.CustomRuleCreation {
    public class CustomRuleCreationUseCase : IRequestHandler<CreateRuleCommand, int>
    {
        private readonly IAsyncRepository<Rule> _ruleRepository;
        public CustomRuleCreationUseCase(IAsyncRepository<Rule> ruleRepository)
        {
            _ruleRepository = ruleRepository;
        }
        public Task<int> Handle(CreateRuleCommand request, CancellationToken cancellationToken)
        {
            var rule = new Rule
            {
                Name = request.Name,
                Description = request.Description,
                ChannelId = request.ChannelId,
                ActionId = request.ActionId,
                ConditionId = request.ConditionId,
                RewardId = request.RewardId
            };
        }

    }

    public class CreateRuleCommand : IRequest<int>{
        public string Name { get; set; }
        public string Description { get; set; }
        public int ChannelId { get; set; }
        public int ActionId { get; set; }
        public int ConditionId { get; set; }
        public int RewardId { get; set; }
    }
}