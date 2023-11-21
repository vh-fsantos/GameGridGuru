using System.Collections.ObjectModel;
using GameGridGuru.Domain.Models;
using GameGridGuru.UI.Abstractions.ViewModels;

namespace GameGridGuru.UI.ViewModels.ContextViewModels;

public class SelectedCardViewModel : BaseViewModel, IContextViewModel
{
    private readonly Card _currentCard;
    private ObservableCollection<CardProduct> _cardProducts;
    private ObservableCollection<Reservation> _reservations;
    private bool _hasReservation;

    public SelectedCardViewModel(Card card)
    {
        _currentCard = card;
        HasReservation = _currentCard.Reservation != null;
        Reservations = new ObservableCollection<Reservation>();
        CardProducts = new ObservableCollection<CardProduct>();
        LoadCardProducts();
    }
    
    public string Title => $"Cliente: {_currentCard.Customer!.Name}";

    public ObservableCollection<Reservation> Reservations
    {
        get => _reservations;
        set
        {
            _reservations = value;
            OnPropertyChanged(nameof(Reservations));
        }
    }

    
    public ObservableCollection<CardProduct> CardProducts
    {
        get => _cardProducts;
        set
        {
            _cardProducts = value;
            OnPropertyChanged(nameof(CardProducts));
        }
    }

    public bool HasReservation
    {
        get => _hasReservation;
        set
        {
            _hasReservation = value;
            OnPropertyChanged(nameof(HasReservation));
        }
    }

    private void LoadCardProducts()
    {
        if (_currentCard.Reservation != null)
            Reservations.Add(_currentCard.Reservation);
        
        foreach (var cardProduct in _currentCard.Products)
            CardProducts.Add(cardProduct);
    }
}