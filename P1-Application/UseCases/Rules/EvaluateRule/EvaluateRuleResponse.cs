using MediatR;

namespace P1_Application.UseCases.Rules.EvaluateRule
{
    public class EvaluateRuleResponse : IRequest
    {
        public int Id { get; set; }

        public EvaluateRuleResponse(int id)
        {
            Id = id;
        }
    }
}