using MediatR;

namespace P1_Application.UseCases.Conditions.GetCondition
{
    public class GetConditionQuery : IRequest<GetConditionResponse>
    {
        public int Id { get; set; }
    }
}