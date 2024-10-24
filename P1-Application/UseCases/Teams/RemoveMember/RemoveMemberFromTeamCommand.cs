using MediatR;

namespace P1_Application.UseCases.Teams.RemoveMemberFromTeam
{
    public class RemoveMemberFromTeamCommand : IRequest
    {
        public int TeamId { get; set; }
        public int DiscordUserId { get; set; }
    }
}