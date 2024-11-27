using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Teams.AddMemberToLegion
{
    public class AddMemberToTeamUseCase : IRequestHandler<AddMemberToLegionCommand>
    {
        private readonly IRepository<OrganizationLegion> _OrganizationLegionRepository;


        public AddMemberToTeamUseCase(IRepository<OrganizationLegion> organizationLegionRepository)
        {
            _OrganizationLegionRepository = organizationLegionRepository;
        }

        public async Task Handle(AddMemberToLegionCommand request, CancellationToken cancellationToken)
        {
            await _OrganizationLegionRepository.AddAsync(new OrganizationLegion { LegionId = request.LegionId, OrganizationId = request.OrganizationId });
        }

    }
}