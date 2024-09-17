using MediatR;

namespace P1_Application.UseCases.Conditions.CreateCondition
{
    public class CreateConditionResponse : IRequest
    {
        public int Id { get; set; }

        public CreateConditionResponse(int id)
        {
            Id = id;
        }
    }
}