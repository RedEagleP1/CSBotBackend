namespace P1_Core.Entities
{
    /// <summary>
    /// This entity represents an organization, which is the same thing as a division in P1.
    /// </summary>
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Team>? MemberTeams { get; set; }
        public Team Team { get; set; } // The Id of the team that is leading this organization
        public DiscordUser DiscordUser { get; set; } // The user Id of the organization leader
    }
}