using P1_Core.Entities;
using MediatR;

namespace P1_Application.UseCases.Conditions.GetCondition
{
    public class GetConditionResponse : IRequest
    {
        public Condition Condition { get; private set; }

        public GetConditionResponse(Condition condition)
        {
            Condition = condition;
        }
    }
}