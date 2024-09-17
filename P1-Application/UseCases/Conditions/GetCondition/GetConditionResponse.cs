using MediatR;

namespace P1_Application.UseCases.Conditions.GetCondition
{
    public class GetConditionResponse : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}