using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using GameGridGuru.Domain.Models;
using GameGridGuru.Services.Abstractions.Services;
using GameGridGuru.UI.Abstractions.Services;
using GameGridGuru.UI.Abstractions.ViewModels;
using GameGridGuru.UI.ViewModels.HandlersViewModel;
using GameGridGuru.UI.Views.Dialogs;

namespace GameGridGuru.UI.ViewModels;

public partial class CardViewModel : BaseViewModel, IContextViewModel
{
    private ObservableCollection<Card> _cards;
    private Card _selectedCard;
    private bool _isCardSelected;
    
    public CardViewModel(IPopupService popupService, ICardService cardService) : base(popupService)
    {
        CardService = cardService;

        LoadCardsAsync();
    }
    
    private ICardService CardService { get; }
    
    public string Title => "Comandas";
    
    public ObservableCollection<Card> Cards
    {
        get => _cards;
        set
        {
            _cards = value;
            OnPropertyChanged(nameof(Cards));
        }
    }

    public Card SelectedCard
    {
        get => _selectedCard;
        set
        {
            _selectedCard = value;
            IsCardSelected = value != null;
            OnPropertyChanged(nameof(SelectedCard));
        }
    }

    public bool IsCardSelected
    {
        get => _isCardSelected;
        set
        {
            _isCardSelected = value;
            OnPropertyChanged(nameof(IsCardSelected));
        }
    }

    [RelayCommand]
    private async Task AddCard()
    {
        var context = new HandlerCardViewModel();
        var view = new HandlerCardView { BindingContext = context };
        var cardInfo = await PopupService!.ShowPopupAsync(view);

        if (cardInfo is not Card card)
            return;
    }

    private void LoadCardsAsync()
    {
        Cards = new ObservableCollection<Card>()
        {
            new Card() { Id = 01, Customer = new Customer() { Name = "Vitor" }, TotalValue = 27.5F },
            new Card() { Id = 01, Customer = new Customer() { Name = "Vitor" }, TotalValue = 27.5F },
            new Card() { Id = 01, Customer = new Customer() { Name = "Vitor" }, TotalValue = 27.5F }
        };
    }
}