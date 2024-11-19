using MediatR;
using P1_Core.Enums;

namespace P1_Application.UseCases.ContainerRegistry.CreateContainer
{
    public class ContainerRequestCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ContainerType Type { get; set; }
        public IList<int>? Members { get; set; }
        public int? ParentId { get; set; }
    }
}