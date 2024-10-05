
namespace P1_Api.Models.Legions
{
	public class CreateLegionRequestModel
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public int LeadingTeamId { get; set; }
		public int LegionLeaderId { get; set; }
	}
}