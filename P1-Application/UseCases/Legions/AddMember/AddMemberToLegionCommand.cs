using MediatR;

namespace P1_Application.UseCases.Teams.AddMemberToLegion
{
    public class AddMemberToLegionCommand : IRequest
    {
        public int LegionId { get; set; }
        public int OrganizationId { get; set; }
    }
}