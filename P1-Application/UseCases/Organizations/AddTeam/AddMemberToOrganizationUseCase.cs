using MediatR;
using P1_Core.Interfaces;
using P1_Core.Entities.JoinTables;
using Microsoft.Extensions.Logging;

namespace P1_Application.UseCases.Teams.AddMemberToOrganization
{
    public class AddMemberToTeamUseCase : IRequestHandler<AddMemberToOrganizationCommand>
    {
        private readonly IRepository<TeamOrganization> _TeamOrganizationRepository;


        public AddMemberToTeamUseCase(IRepository<TeamOrganization> teamOrganizationRepository)
        {
            _TeamOrganizationRepository = teamOrganizationRepository;
        }

        public async Task Handle(AddMemberToOrganizationCommand request, CancellationToken cancellationToken)
        {
            await _TeamOrganizationRepository.AddAsync(new TeamOrganization { OrganizationId = request.OrganizationId, TeamId = request.TeamId });
        }

    }
}