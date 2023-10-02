using System.ComponentModel.DataAnnotations.Schema;

namespace GameGridGuru.Domain.Models;

public class Invoice
{
    public int Id { get; set; }
    public float TotalValue { get; set; }
    [ForeignKey("Invoice_Card_Fk1")]
    public int CardId { get; set; }
    public virtual Card? Card { get; set; }
}