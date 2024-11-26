using MediatR;
using P1_Core.Enums;

namespace P1_Application.UseCases.ContainerRegistry.GetContainerByType
{
    public class ContainerQuery : IRequest<ContainerQueryResponse>
    {
        public ContainerType Type { get; set; }
    }

}