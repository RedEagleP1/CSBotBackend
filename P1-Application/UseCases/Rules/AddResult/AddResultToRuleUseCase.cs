using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Rules.AddResultToRule
{
    public class AddResultToRuleUseCase : IRequestHandler<AddResultToRuleCommand>
    {
        private readonly IRepository<ResultRule> _RuleRepository;
        private readonly ILogger _Logger;


        public AddResultToRuleUseCase(IRepository<ResultRule> ruleRepository, ILogger logger)
        {
            _RuleRepository = ruleRepository;
            _Logger = logger;
        }

        public async Task Handle(AddResultToRuleCommand request, CancellationToken cancellationToken)
        {
            await _RuleRepository.AddAsync(new ResultRule { RuleId = request.RuleId, ResultId = request.ResultId });
        }

    }
}