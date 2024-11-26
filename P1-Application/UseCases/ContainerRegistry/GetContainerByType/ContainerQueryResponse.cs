using P1_Core.Enums;

namespace P1_Application.UseCases.ContainerRegistry.GetContainerByType
{
    public class ContainerQueryResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ContainerType Type { get; set; }
        public IList<int>? Members { get; set; }
        public IList<ContainerQueryResponse>? Children { get; set; }
    }

}