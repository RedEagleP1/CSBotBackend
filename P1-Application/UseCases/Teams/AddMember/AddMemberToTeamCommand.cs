using MediatR;

namespace P1_Application.UseCases.Teams.AddMemberToTeam
{
    public class AddMemberToTeamCommand : IRequest
    {
        public int TeamId { get; set; }
        public int DiscordUserId { get; set; }
    }
}