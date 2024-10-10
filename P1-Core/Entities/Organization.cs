namespace P1_Core.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Team>? MemberTeams { get; set; }
        public int LeadingTeamId { get; set; } // The Id of the team that is leading this organization
        public int OrganizationLeaderId { get; set; } // The user Id of the organization leader
    }
}