using MediatR;

namespace P1_Application.UseCases.Conditions.CreateRule
{
    public class CreateRuleCommand : IRequest<CreateRuleResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection Conditions { get; set; }
        public ICollection Results { get; set; }
    }
}