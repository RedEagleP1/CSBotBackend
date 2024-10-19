using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Teams.RemoveMemberFromOrganization
{
    public class RemoveMemberFromTeamUseCase : IRequestHandler<RemoveMemberFromOrganizationCommand>
    {
        private readonly IRepository<TeamOrganization> _TeamDiscordUserRepository;
        private readonly ILogger _Logger;


        public RemoveMemberFromTeamUseCase(IRepository<TeamOrganization> teamDiscordUserRepository, ILogger logger)
        {
            _TeamDiscordUserRepository = teamDiscordUserRepository;
            _Logger = logger;
        }

        public async Task Handle(RemoveMemberFromOrganizationCommand request, CancellationToken cancellationToken)
        {
            await _TeamDiscordUserRepository.DeleteAsync(new TeamOrganization { OrganizationId = request.OrganizationId, TeamId = request.TeamId });
        }

    }
}