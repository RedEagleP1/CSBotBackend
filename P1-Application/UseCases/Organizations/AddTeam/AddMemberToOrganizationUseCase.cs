using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Teams.AddMemberToOrganization
{
    public class AddMemberToTeamUseCase : IRequestHandler<AddMemberToOrganizationCommand>
    {
        private readonly IRepository<TeamOrganization> _TeamOrganizationRepository;
        private readonly ILogger _Logger;


        public AddMemberToTeamUseCase(IRepository<TeamOrganization> teamOrganizationRepository, ILogger logger)
        {
            _TeamOrganizationRepository = teamOrganizationRepository;
            _Logger = logger;
        }

        public async Task Handle(AddMemberToOrganizationCommand request, CancellationToken cancellationToken)
        {
            await _TeamOrganizationRepository.AddAsync(new TeamOrganization { OrganizationId = request.OrganizationId, TeamId = request.TeamId });
        }

    }
}