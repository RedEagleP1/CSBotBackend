using MediatR;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.GetAllRules
{
    public class GetAllRulesResponse : IRequest
    {
        public List<Rule> Rules { get; private set; }

        public GetAllRulesResponse(List<Rule> rules)
        {
            Rules = rules;
        }
    }
}