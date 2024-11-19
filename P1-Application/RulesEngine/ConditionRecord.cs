namespace P1_Application.RulesEngine
{
    public class ConditionRecord {
        public string Type { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public int Id { get; set; }
    }
}
