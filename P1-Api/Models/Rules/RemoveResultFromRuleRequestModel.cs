using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Api.Models.Rules
{
	public class RemoveResultFromRuleRequestModel
	{
		public int RuleId { get; set; }
		public int ResultId { get; set; }
	}
}