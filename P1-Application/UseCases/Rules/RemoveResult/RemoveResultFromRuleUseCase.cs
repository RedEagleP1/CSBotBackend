using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Application.Exceptions;
using P1_Core.Entities.JoinTables;
using Microsoft.Extensions.Logging;

namespace P1_Application.UseCases.Rules.RemoveResultFromRule
{
    public class RemoveResultFromRuleUseCase : IRequestHandler<RemoveResultFromRuleCommand>
    {
        private readonly IRepository<ResultRule> _ResultRuleRepository;


        public RemoveResultFromRuleUseCase(IRepository<ResultRule> resultRuleRepository)
        {
            _ResultRuleRepository = resultRuleRepository;
        }

        public async Task Handle(RemoveResultFromRuleCommand request, CancellationToken cancellationToken)
        {
            await _ResultRuleRepository.DeleteAsync(new ResultRule { RuleId = request.RuleId, ResultId = request.ResultId });

        }

    }
}