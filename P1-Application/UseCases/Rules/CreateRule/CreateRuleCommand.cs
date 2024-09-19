using MediatR;
using P1_Core.Entities;

namespace P1_Application.UseCases.Rules.CreateRule
{
    public class CreateRuleCommand : IRequest<CreateRuleResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<Condition> Conditions { get; set; }
        public ICollection<Result> Results { get; set; }

    }
}