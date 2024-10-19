using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Api.Models.Teams
{
	public class AddGameToTeamRequestModel
	{
		public int TeamId { get; set; }
		public ulong GameId { get; set; }
	}
}