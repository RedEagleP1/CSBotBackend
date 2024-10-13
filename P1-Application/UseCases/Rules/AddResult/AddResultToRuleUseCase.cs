using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.AddResultToRule
{
    public class AddResultToRuleUseCase : IRequestHandler<AddResultToRuleCommand>
    {
        private readonly IRepository<Rule> _RuleRepository;
        private readonly IRepository<Result> _ResultRepository;
        private readonly ILogger _Logger;


        public AddResultToRuleUseCase(IRepository<Rule> ruleRepository, IRepository<Result> ResultRepository, ILogger logger)
        {
            _RuleRepository = ruleRepository;
            _ResultRepository = ResultRepository;
            _Logger = logger;
        }

        public async Task Handle(AddResultToRuleCommand request, CancellationToken cancellationToken)
        {
            // Find the rule and the result to add.
            var rule = await _RuleRepository.GetByIdAsync(request.RuleId);
            if (rule == null) throw new P1Exception(_Logger, $"Rule with id {request.RuleId} not found");

            var result = await _ResultRepository.GetByIdAsync(request.ResultId);
            if (result == null) throw new P1Exception(_Logger, $"Result with id {request.ResultId} not found");

            if (!rule.Results.Contains(result)) throw new P1Exception(_Logger, $"Rule with id {request.RuleId} already contains result with id {request.ResultId} not found");

            // Add the result to the rule
            rule.Results.Add(result);

            // Save the changes
            await _RuleRepository.UpdateAsync(rule);
        }

    }
}