using MediatR;

namespace P1_Application.UseCases.Teams.RemoveGameFromTeam
{
    public class RemoveGameFromTeamCommand : IRequest
    {
        public int TeamId { get; set; }
        public int GameId { get; set; }
    }
}