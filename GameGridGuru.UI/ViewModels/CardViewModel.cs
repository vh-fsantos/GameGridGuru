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
    
    public CardViewModel(IPopupService popupService, ICardService cardService, ICustomerService customerService, ICourtService courtService, IProductService productService, IReservationService reservationService) : base(popupService)
    {
        CardService = cardService;
        CustomerService = customerService;
        CourtService = courtService;
        ProductService = productService;
        ReservationService = reservationService;
        
        LoadCardsAsync();
    }
    
    private ICardService CardService { get; }
    private ICustomerService CustomerService { get; }
    private ICourtService CourtService { get; }
    private IProductService ProductService { get; }
    private IReservationService ReservationService { get; }
    
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
        var context = new HandlerCardViewModel(await GetAllCustomer(), await GetAllCourts());
        var view = new HandlerCardView { BindingContext = context };
        var result = await PopupService!.ShowPopupAsync(view);
        
        if (result is null or false)
            return;

        var card = context.GetCard();
        var reservation = context.GetReservation();

        if (reservation != null)
        {
            reservation = await ReservationService.AddReservationAsync(reservation) ?? throw new Exception("Error obtaining reservation");
            card.ReservationId = reservation.Id;
        }

        if (await CardService.AddEntityAsync(card));
            await LoadCardsAsync();
    }

    private async Task LoadCardsAsync()
    {
        Cards = new ObservableCollection<Card>(await CardService.GetAllCardsAsync());
    }

    private async Task<IEnumerable<Customer>> GetAllCustomer()
        => await CustomerService.GetAllAsync();
    
    private async Task<IEnumerable<Court>> GetAllCourts()
        => await CourtService.GetAllAsync();
}