using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Teams.RemoveMemberFromTeam
{
    public class RemoveMemberFromTeamUseCase : IRequestHandler<RemoveMemberFromTeamCommand>
    {
        private readonly IRepository<DiscordUserTeam> _TeamDiscordUserRepository;
        private readonly ILogger _Logger;


        public RemoveMemberFromTeamUseCase(IRepository<DiscordUserTeam> teamDiscordUserRepository, ILogger logger)
        {
            _TeamDiscordUserRepository = teamDiscordUserRepository;
            _Logger = logger;
        }

        public async Task Handle(RemoveMemberFromTeamCommand request, CancellationToken cancellationToken)
        {
            await _TeamDiscordUserRepository.DeleteAsync(new DiscordUserTeam { TeamId = request.TeamId, DiscordUserId = request.DiscordUserId });
        }

    }
}