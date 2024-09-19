using MediatR;
using P1_Core.Entities;

namespace P1_Application.UseCases.Conditions.GetAllConditions
{
    public class GetAllConditionsResponse : IRequest
    {
        public List<Condition> Conditions { get; private set; }

        public GetAllConditionsResponse(List<Condition> conditions)
        {
            Conditions = conditions;
        }
    }
}