namespace GameGridGuru.Domain.Models;

public class Court : EntityId
{
    public string Name { get; set; } = default!;
    public float HourValue { get; set; }
}