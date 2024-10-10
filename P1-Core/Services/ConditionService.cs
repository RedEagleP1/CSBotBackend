using P1_Core.Interfaces;

namespace P1_Core.Services
{
    public class ConditionService : IConditionService
    {
        public bool EvaluateCondition(Condition condition, object target)
        {

            var property = target.GetType().GetProperty(condition.Name);
            var targetValue = property.GetValue(target)?.ToString();

            switch (condition.Operation)
            {
                case "Equals":
                    return condition.ExpectedResult == targetValue;
                case "NotEquals":
                    return condition.ExpectedResult != targetValue;
                case "GreaterThan":
                    return CompareProperties(condition.ExpectedResult, targetValue) < 0;
                case "LessThan":
                    return CompareProperties(condition.ExpectedResult, targetValue) > 0;

                default:
                    return false;

            } // end switch
        }

        private int CompareProperties(string property1, string property2)
        {
            double.TryParse(property1, out double result1);
            double.TryParse(property2, out double result2);

            return result1.CompareTo(result2);
        }
    }
}