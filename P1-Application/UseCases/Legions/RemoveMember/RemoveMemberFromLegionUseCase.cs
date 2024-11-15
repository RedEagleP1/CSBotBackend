using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;

using ILogger = Serilog.ILogger;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Teams.RemoveMemberFromLegion
{
    public class RemoveMemberFromLegionUseCase : IRequestHandler<RemoveMemberFromLegionCommand>
    {
        private readonly IRepository<OrganizationLegion> _OrganizationLegionRepository;
        private readonly ILogger _Logger;


        public RemoveMemberFromLegionUseCase(IRepository<OrganizationLegion> organizationLegionRepository, ILogger logger)
        {
            _OrganizationLegionRepository = organizationLegionRepository;
            _Logger = logger;
        }

        public async Task Handle(RemoveMemberFromLegionCommand request, CancellationToken cancellationToken)
        {
            await _OrganizationLegionRepository.DeleteAsync(new OrganizationLegion { LegionId = request.LegionId, OrganizationId = request.OrganizationId, });
        }

    }
}