using MediatR;

namespace P1_Application.UseCases.Teams.AddGameToTeam
{
    public class AddGameToTeamCommand : IRequest
    {
        public int TeamId { get; set; }
        public int GameId { get; set; }
    }
}