using MediatR;

namespace P1_Application.UseCases.Conditions.DeleteCondition
{
    public class DeleteConditionCommand : IRequest<DeleteConditionResponse>
    {
        public int Id { get; set; }
    }
}