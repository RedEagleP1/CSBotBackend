namespace P1_Core.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<DiscordUser>? TeamMembers { get; set; }
        public ICollection<Game>? Games { get; set; } // Games this team has worked on
        public int TeamLeaderId { get; set; } // Team leader's user Id
        public int CurrentGameId { get; set; } // The Id of the team's current project
    }
}