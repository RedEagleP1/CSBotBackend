using P1_Core.Enums;

namespace P1_Core.Entities
{
    public class Container : BaseEntity
    {
        public string Name { get; set; }

        //todo This should be indexed as it'll be used often to filter containers
        public ContainerType Type { get; set; }
        public Container? Parent { get; set; }
    }
}