namespace P1_Application.RulesEngine
{
    public class ResultRecord
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public Dictionary<string, object> Parameters { get; set; } = new();
    }
}
