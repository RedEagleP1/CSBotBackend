using MediatR;

namespace P1_Application.UseCases.Rules.CreateRule
{
    public class CreateRuleResponse : IRequest
    {
        public int Id { get; set; }

        public CreateRuleResponse(int id)
        {
            Id = id;
        }
    }
}