namespace GameGridGuru.Domain.Models;

public class Customer : EntityId
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}