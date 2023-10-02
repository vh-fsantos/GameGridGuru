namespace GameGridGuru.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public float Value { get; set; }
}