
namespace P1_Api.Models.Teams
{
	public class CreateTeamRequestModel
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public int TeamLeaderId { get; set; }
	}
}