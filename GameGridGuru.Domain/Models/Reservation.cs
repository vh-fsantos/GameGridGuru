using System.ComponentModel.DataAnnotations.Schema;

namespace GameGridGuru.Domain.Models;

public class Reservation : EntityId
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    [ForeignKey("Reservation_Court_Fk1")]
    public int CourtId { get; set; }
    public Court? Court { get; set; }
}