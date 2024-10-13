namespace P1_Core.Entities
{
    public class Legion : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Organization>? MemberOrganizations { get; set; }
        public int LeadingTeamId { get; set; } // The Id of the team that is leading this legion
        public int LegionLeaderId { get; set; } // The user Id of the legion leader
    }
}