using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Api.Models.Rules
{
	public class SetRuleEnabledStateRequestModel
	{
		public int RuleId { get; set; }
		public bool EnabledState { get; set; }
	}
}