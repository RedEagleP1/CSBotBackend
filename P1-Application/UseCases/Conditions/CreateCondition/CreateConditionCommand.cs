using MediatR;

namespace P1_Application.UseCases.Conditions.CreateCondition
{
    public class CreateConditionCommand : IRequest<CreateConditionResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}