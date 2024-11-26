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
        private readonly ILogger _Logger;


        public RemoveGameFromTeamUseCase(IRepository<GameTeam> gameTeamRepository, ILogger logger)
        {
            _GameTeamRepository = gameTeamRepository;
            _Logger = logger;
        }

        public async Task Handle(RemoveGameFromTeamCommand request, CancellationToken cancellationToken)
        {
            await _GameTeamRepository.DeleteAsync(new GameTeam { TeamId = request.TeamId, GameId = request.GameId });
        }

    }
}