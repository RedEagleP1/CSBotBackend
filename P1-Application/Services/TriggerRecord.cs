
// TODO Database records... maybe, or move to existing ones
public class TriggerRecord
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public Dictionary<string, object> Parameters { get; set; } = new();
}
