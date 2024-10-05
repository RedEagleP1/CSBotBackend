
namespace P1_Api.Models.Organizations
{
	public class CreateOrganizationRequestModel
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public int LeadingTeamId { get; set; }
		public int OrganizationLeaderId { get; set; }
	}
}