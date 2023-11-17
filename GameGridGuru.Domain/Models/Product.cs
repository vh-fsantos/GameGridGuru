namespace GameGridGuru.Domain.Models;

public class Product : EntityId
{
    public string Name { get; set; } = string.Empty;
    public float Value { get; set; }
}