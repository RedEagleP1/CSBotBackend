using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Teams.RemoveGameFromTeam
{
    public class RemoveGameFromTeamUseCase : IRequestHandler<RemoveGameFromTeamCommand>
    {
        private readonly IRepository<GameTeam> _GameTeamRepository;

        public RemoveGameFromTeamUseCase(IRepository<GameTeam> gameTeamRepository)
        {
            _GameTeamRepository = gameTeamRepository;
        }

        public async Task Handle(RemoveGameFromTeamCommand request, CancellationToken cancellationToken)
        {
            await _GameTeamRepository.DeleteAsync(new GameTeam { TeamId = request.TeamId, GameId = request.GameId });
        }

    }
}