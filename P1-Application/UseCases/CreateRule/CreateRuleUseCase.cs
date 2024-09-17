using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.CreateRule
{

    public class CreateRuleUseCase : IRequestHandler<CreateRuleRequest>
    {
        private readonly IRepository<Rule> _ruleRepository;
        public CreateRuleUseCase(IRepository<Rule> ruleRepository)
        {
            _ruleRepository = ruleRepository;
        }

        public async Task Handle(CreateRuleRequest request, CancellationToken cancellationToken)
        {
            var ruleId = await _ruleRepository.AddAsync(new Rule());
        }
    }

    public class CreateRuleRequest: IRequest
    {
    }
}