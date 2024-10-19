using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Api.Models.Organizations
{
	public class AddMemberToOrganizationRequestModel
	{
		public int OrganizationId { get; set; }
		public ulong TeamId { get; set; }
	}
}