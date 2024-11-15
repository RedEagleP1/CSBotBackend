using System.Reflection.Metadata;
using P1_Core.Entities;

namespace P1_Core.Entities
{
    public class DiscordCommand : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<DiscordCommandOptions> Options { get; set; }
    }
}