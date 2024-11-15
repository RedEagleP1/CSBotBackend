using P1_Core.Enums;

namespace P1_Api.Models.ContainerRegistry
{
    public class ContainerRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ContainerType Type { get; set; }
        public IList<int>? Members { get; set; }
        public int? ParentId { get; set; }
    }
}
