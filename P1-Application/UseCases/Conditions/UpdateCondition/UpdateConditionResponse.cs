using MediatR;
using P1_Core.Entities;

namespace P1_Application.UseCases.Conditions.UpdateCondition
{
    public class UpdateConditionResponse : IRequest
    {
        public Condition Condition { get; private set; }

        public UpdateConditionResponse(Condition condition)
        {
            Condition = condition;
        }
    }
}