using MediatR;
using P1_Core.Interfaces;
using P1_Core.Entities.JoinTables;
using Microsoft.Extensions.Logging;

namespace P1_Application.UseCases.Teams.AddGameToTeam
{
    public class AddGameToTeamUseCase : IRequestHandler<AddGameToTeamCommand>
    {
        private readonly IRepository<GameTeam> _GameTeamRepository;


        public AddGameToTeamUseCase(IRepository<GameTeam> gameTeamRepository)
        {
            _GameTeamRepository = gameTeamRepository;
        }

        public async Task Handle(AddGameToTeamCommand request, CancellationToken cancellationToken)
        {
            await _GameTeamRepository.AddAsync(new GameTeam { TeamId = request.TeamId, GameId = request.GameId });
        }

    }
}