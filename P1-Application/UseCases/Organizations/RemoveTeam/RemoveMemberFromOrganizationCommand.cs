using MediatR;

namespace P1_Application.UseCases.Teams.RemoveMemberFromOrganization
{
    public class RemoveTeamFromOrganizationCommand : IRequest
    {
        public int OrganizationId { get; set; }
        public int TeamId { get; set; }
    }
}