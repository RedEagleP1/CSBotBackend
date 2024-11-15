using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Api.Models.Legions
{
	public class RemoveOrgFromLegionRequestModel
	{
		public int LegionId { get; set; }
		public int OrganizationId { get; set; }
	}
}