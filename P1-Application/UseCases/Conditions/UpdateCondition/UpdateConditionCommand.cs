using MediatR;
using P1_Core.Entities;

namespace P1_Application.UseCases.Conditions.UpdateCondition
{
    public class UpdateConditionCommand : IRequest<UpdateConditionResponse>
    {
        public Condition Condition { get; set; }
    }
}