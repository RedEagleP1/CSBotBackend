using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Api.Models.Organizations
{
	public class RemoveMemberFromOrganizationRequestModel
	{
		public int OrganizationId { get; set; }
		public int TeamId { get; set; }
	}
}