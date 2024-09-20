using MediatR;
using P1_Application.UseCases;
using P1_Core;
using P1_Core.Entities;


namespace P1_Application.UseCases.Rules.CreateRule
{

    public class CreateRuleUseCase : IRequestHandler<CreateRuleCommand, CreateRuleResponse>
    {
        private readonly IRepository<Rule> _ruleRepository;

        public CreateRuleUseCase(IRepository<Rule> ruleRepository)
        {
            _ruleRepository = ruleRepository;
        }

        public async Task<CreateRuleResponse> Handle(CreateRuleCommand request, CancellationToken cancellationToken)
        {
            AddOneEntityRequest<Rule> ruleToAdd = new AddOneEntityRequest<Rule>(new Rule
            {
                Name = request.Name,
                Description = request.Description,
                IsEnabled = request.IsEnabled,
                Conditions = request.Conditions,
                Results = request.Results,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });

            AddOneEntityResponse response = new AddEntityUseCase<Rule>(_ruleRepository).Handle(ruleToAdd, cancellationToken).Result;

            return new CreateRuleResponse(response.Id);
        }

    }
}