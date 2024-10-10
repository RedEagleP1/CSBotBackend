
using P1_Core.Interfaces;

namespace P1_Api.Models.Rules
{
	public class CreateRuleRequestModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsEnabled { get; set; }
		public ICollection<Condition> Conditions { get; set; }
	}
}