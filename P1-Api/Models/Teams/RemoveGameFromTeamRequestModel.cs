using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Api.Models.Teams
{
	public class RemoveGameFromTeamRequestModel
	{
		public int TeamId { get; set; }
		public int GameId { get; set; }
	}
}