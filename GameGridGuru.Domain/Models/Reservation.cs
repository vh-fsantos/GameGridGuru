using System.ComponentModel.DataAnnotations.Schema;

namespace GameGridGuru.Domain.Models;

public class Reservation
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    [ForeignKey("Reservation_Court_Fk1")]
    public int CourtId { get; set; }
    public Court? Court { get; set; }
}