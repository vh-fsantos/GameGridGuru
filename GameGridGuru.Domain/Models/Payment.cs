using System.ComponentModel.DataAnnotations.Schema;

namespace GameGridGuru.Domain.Models;

public class Payment
{
    public int Id { get; set; }
    public float TotalValue { get; set; }
    [ForeignKey("Payment_Invoice_Fk1")]
    public int InvoiceId { get; set; }
    public virtual Invoice? Invoice { get; set; }
}