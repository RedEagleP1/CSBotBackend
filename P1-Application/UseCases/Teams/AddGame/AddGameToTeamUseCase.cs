using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Teams.AddGameToTeam
{
    public class AddGameToTeamUseCase : IRequestHandler<AddGameToTeamCommand>
    {
        private readonly IRepository<GameTeam> _GameTeamRepository;
        private readonly ILogger _Logger;


        public AddGameToTeamUseCase(IRepository<GameTeam> gameTeamRepository, ILogger logger)
        {
            _GameTeamRepository = gameTeamRepository;
            _Logger = logger;
        }

        public async Task Handle(AddGameToTeamCommand request, CancellationToken cancellationToken)
        {
            await _GameTeamRepository.AddAsync(new GameTeam { TeamId = request.TeamId, GameId = request.GameId });
        }

    }
}