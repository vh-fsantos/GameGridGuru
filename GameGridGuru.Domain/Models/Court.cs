namespace GameGridGuru.Domain.Models;

public class Court
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public float HourValue { get; set; }
}