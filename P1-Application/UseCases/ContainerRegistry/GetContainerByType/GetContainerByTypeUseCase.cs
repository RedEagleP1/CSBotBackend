using MediatR;
using P1_Core.Enums;

namespace P1_Application.UseCases.ContainerRegistry.GetContainerByType
{
    public class GetContainerByTypeUseCase : IRequestHandler<ContainerQuery, ContainerQueryResponse>
    {
        public Task<ContainerQueryResponse> Handle(ContainerQuery request, CancellationToken cancellationToken)
        {
            switch (request.Type)
            {
                case ContainerType.Legion:
                    // TODO: Call legion get use case
                    break;
                case ContainerType.Team:
                    // TODO: Call team get use case
                    break;
                case ContainerType.Division:
                    // TODO: Call division get use case
                    break;
                case ContainerType.Container:
                    // TODO: Call Container get use case
                    break;
            }
        }
    }

    public class ContainerQuery : IRequest<ContainerQueryResponse>
    {
        public ContainerType Type { get; set; }
    }

    public class ContainerQueryResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ContainerType Type { get; set; }
        public IList<int>? Members { get; set; }
        public int? ParentId { get; set; }
    }
}