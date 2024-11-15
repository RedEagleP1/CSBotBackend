using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Api.Models.Rules
{
	public class AddConditionToRuleRequestModel
	{
		public int RuleId { get; set; }
		public int ConditionId { get; set; }
	}
}