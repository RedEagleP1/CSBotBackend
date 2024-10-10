
namespace P1_Application.Services.RulesEngine
{
    public class TriggerRecord {
        public string Type { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public int Id { get; set; }
    }
}
