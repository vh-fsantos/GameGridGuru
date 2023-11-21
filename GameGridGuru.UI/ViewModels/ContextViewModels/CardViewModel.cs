using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using GameGridGuru.Domain.Models;
using GameGridGuru.Services.Abstractions.Services;
using GameGridGuru.UI.Abstractions.Services;
using GameGridGuru.UI.Abstractions.ViewModels;
using GameGridGuru.UI.ViewModels.HandlersViewModel;
using GameGridGuru.UI.Views;
using GameGridGuru.UI.Views.Dialogs;

namespace GameGridGuru.UI.ViewModels.ContextViewModels;

public partial class CardViewModel : BaseViewModel, IContextViewModel
{
    private ObservableCollection<Card> _cards;
    private Card _selectedCard;
    private bool _isCardSelected;
    private View _currentCardPage; 
    
    public CardViewModel(IPopupService popupService, ICardService cardService, ICustomerService customerService, 
        ICourtService courtService, IProductService productService, IReservationService reservationService,
        ICardProductService cardProductService) : base(popupService)
    {
        CardService = cardService;
        CustomerService = customerService;
        CourtService = courtService;
        ProductService = productService;
        ReservationService = reservationService;
        CardProductService = cardProductService;
        
        _ = LoadCardsAsync();
    }
    
    private ICardService CardService { get; }
    private ICustomerService CustomerService { get; }
    private ICourtService CourtService { get; }
    private IProductService ProductService { get; }
    private IReservationService ReservationService { get; }
    private ICardProductService CardProductService { get; }
    
    public string Title => "Comandas";
    
    public View CurrentCardPage
    {
        get => _currentCardPage;
        set
        {
            _currentCardPage = value;
            OnPropertyChanged(nameof(CurrentCardPage));
        }
    }
    
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
            SetCurrentCardPage(value);
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

    [RelayCommand]
    private async Task AddProduct()
    {
        var context = new HandlerCardProductViewModel(await GetAllProducts());
        var view = new HandlerCardProductView { BindingContext = context };
        var result = await PopupService!.ShowPopupAsync(view);

        if (result is null or false)
            return;

        var product = context.GetProduct();
        product.CardId = SelectedCard.Id;

        if (await CardProductService.AddEntityAsync(product))
        {
            await LoadCardsAsync();
            SetCurrentCardPage(Cards.First(card => card.Id == SelectedCard.Id));
        }
    }

    [RelayCommand]
    private async Task FinishCard()
    {
        if (SelectedCard == null)
            return;

        var result = await PopupService!.ShowConfirmationDialog("Finalizando Comanda", "Você está prestes a finalizar essa comanda. Confirma que recebeu o pagamento?");

        if (!result) return;
        
        SelectedCard.IsClosed = true;
        if (await CardService.EditEntityAsync(SelectedCard)) 
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
    
    private async Task<IEnumerable<Product>> GetAllProducts()
        => await ProductService.GetAllAsync();

    private void SetCurrentCardPage(Card card)
    {
        var view = new SelectedCardView { BindingContext = new SelectedCardViewModel(card) };
        CurrentCardPage = view;
    }
}