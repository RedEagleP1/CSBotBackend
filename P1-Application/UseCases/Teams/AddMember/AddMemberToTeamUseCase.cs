using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Teams.AddMemberToTeam
{
    public class AddMemberToTeamUseCase : IRequestHandler<AddMemberToTeamCommand>
    {
        private readonly IRepository<DiscordUserTeam> _DiscordUserTeamRepository;


        public AddMemberToTeamUseCase(IRepository<DiscordUserTeam> discordUserTeamRepository)
        {
            _DiscordUserTeamRepository = discordUserTeamRepository;
        }

        public async Task Handle(AddMemberToTeamCommand request, CancellationToken cancellationToken)
        {
            await _DiscordUserTeamRepository.AddAsync(new DiscordUserTeam { TeamId = request.TeamId, DiscordUserId = request.DiscordUserId });
        }

    }
}