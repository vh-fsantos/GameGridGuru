using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameGridGuru.Domain.Models;

public class Card : EntityId, INotifyPropertyChanged
{
    private float _totalValue;

    public float TotalValue
    {
        get => _totalValue;
        set
        {
            _totalValue = value;
            OnPropertyChanged(nameof(TotalValue));
        }
    }
    public IEnumerable<CardProduct> Products { get; set; } = Enumerable.Empty<CardProduct>();
    [ForeignKey("Card_Reservation_Fk1")]
    public int? ReservationId { get; set; }
    public Reservation? Reservation { get; set; }
    [ForeignKey("Card_Customer_Fk1")]
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}