using System.ComponentModel.DataAnnotations.Schema;

namespace GameGridGuru.Domain.Models;

public class CardProduct
{
    [ForeignKey("Card_Product_Fk1")]
    public int CardId { get; set; }
    public Card? Card { get; set; }
    [ForeignKey("Product_Card_Fk1")]
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
}