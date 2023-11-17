using System.ComponentModel.DataAnnotations.Schema;

namespace GameGridGuru.Domain.Models;

public class Card : EntityId
{
    public float TotalValue { get; set; }
    public List<Product>? Products { get; set; }
    [ForeignKey("Card_Reservation_Fk1")]
    public int ReservationId { get; set; }
    public virtual Reservation? Reservation { get; set; }
    [ForeignKey("Card_Customer_Fk1")]
    public int CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }
}