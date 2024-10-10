public class RuleRecord
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int TriggerId { get; set; }
    public int ResponseId { get; set; }
}
