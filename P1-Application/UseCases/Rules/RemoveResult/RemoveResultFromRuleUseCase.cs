using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Rules.RemoveResultFromRule
{
    public class RemoveResultFromRuleUseCase : IRequestHandler<RemoveResultFromRuleCommand>
    {
        private readonly IRepository<ResultRule> _ResultRuleRepository;
        private readonly ILogger _Logger;


        public RemoveResultFromRuleUseCase(IRepository<ResultRule> resultRuleRepository, ILogger logger)
        {
            _ResultRuleRepository = resultRuleRepository;
            _Logger = logger;
        }

        public async Task Handle(RemoveResultFromRuleCommand request, CancellationToken cancellationToken)
        {
            await _ResultRuleRepository.DeleteAsync(new ResultRule { RuleId = request.RuleId, ResultId = request.ResultId });

        }

    }
}