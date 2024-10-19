using MediatR;

namespace P1_Application.UseCases.Teams.RemoveMemberFromLegion
{
    public class RemoveMemberFromLegionCommand : IRequest
    {
        public int LegionId { get; set; }
        public int OrganizationId { get; set; }
    }
}