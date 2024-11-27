using MediatR;
using P1_Core.Interfaces;
using P1_Application.Exceptions;
using P1_Core.Entities.JoinTables;
using Microsoft.Extensions.Logging;


namespace P1_Application.UseCases.Rules.AddResultToRule
{
    public class AddResultToRuleUseCase : IRequestHandler<AddResultToRuleCommand>
    {
        private readonly IRepository<ResultRule> _RuleRepository;


        public AddResultToRuleUseCase(IRepository<ResultRule> ruleRepository)
        {
            _RuleRepository = ruleRepository;
        }

        public async Task Handle(AddResultToRuleCommand request, CancellationToken cancellationToken)
        {
            await _RuleRepository.AddAsync(new ResultRule { RuleId = request.RuleId, ResultId = request.ResultId });
        }

    }
}