using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Api.Models.Legions
{
	public class AddMemberToLegionRequestModel
	{
		public int LegionId { get; set; }
		public ulong OrganizationId { get; set; }
	}
}