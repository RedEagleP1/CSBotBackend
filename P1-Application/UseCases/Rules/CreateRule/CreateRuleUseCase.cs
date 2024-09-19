using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.CreateRule
{

    public class CreateRuleUseCase : IRequestHandler<CreateRuleCommand, CreateRuleResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Rule> _ruleRepository;

        public CreateRuleUseCase(IMediator mediator, IRepository<Rule> ruleRepository)
        {
            _mediator = mediator;
            _ruleRepository = ruleRepository;
        }

        public async Task<CreateRuleResponse> Handle(CreateRuleCommand request, CancellationToken cancellationToken)
        {
            var rule = new Rule
            {
                Name = request.Name,
                Description = request.Description,
                IsEnabled = request.IsEnabled,
                Conditions = request.Conditions,
                Results = request.Results,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                // TODO Need to add to join table for this condition to allow multiple conditions
                //ConditionId = request.ConditionId,
            };

            int id = await _ruleRepository.AddAsync(rule);

            return new CreateRuleResponse(id);
        }
    }

}