using MediatR;

namespace P1_Application.UseCases.Teams.AddMemberToOrganization
{
    public class AddMemberToOrganizationCommand : IRequest
    {
        public int OrganizationId { get; set; }
        public int TeamId { get; set; }
    }
}