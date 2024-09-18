using MediatR;
using P1_Core.Entities;

namespace P1_Application.UseCases.Conditions.DeleteCondition
{
    public class DeleteConditionResponse : IRequest
    {
        public Condition Condition { get; set; }

        public DeleteConditionResponse(Condition condition)
        {
            Condition = condition;
        }
    }
}