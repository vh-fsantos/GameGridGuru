using GameGridGuru.Services.Abstractions.Services;
using GameGridGuru.UI.Abstractions.Services;
using GameGridGuru.UI.Abstractions.ViewModels;
using GameGridGuru.UI.Views;

namespace GameGridGuru.UI.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly Timer _timer;
    private List<IContextViewModel> _menuItems;
    private IContextViewModel _selectedItem;
    private View _currentPage;
    private string _currentTime;

    public MainViewModel(IPopupService popupService, ICustomerService customerService, IProductService productService, ICourtService courtService, ICardService cardService)
    {
        _menuItems = new List<IContextViewModel>
        {
            new CardViewModel(popupService, cardService),
            new CourtViewModel(popupService, courtService),
            new CustomerViewModel(popupService, customerService),
            new ProductViewModel(popupService, productService)
        };

        _timer = new Timer(_ => UpdateTime(), null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
    }

    public List<IContextViewModel> MenuItems
    {
        get => _menuItems;
        set
        {
            _menuItems = value;
            OnPropertyChanged(nameof(MenuItems));
        }
    }

    public IContextViewModel SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            SetCurrentPage(_selectedItem);
            OnPropertyChanged(nameof(SelectedItem));
        }
    }
    
    public View CurrentPage
    {
        get => _currentPage;
        set
        {
            _currentPage = value;
            OnPropertyChanged(nameof(CurrentPage));
        }
    }

    public string CurrentTime
    {
        get => _currentTime;
        set
        {
            if (_currentTime != value)
            {
                _currentTime = value;
                OnPropertyChanged(nameof(CurrentTime));
            }
        }
    }
    
    private void SetCurrentPage(IContextViewModel viewModel)
    {
        switch (viewModel)
        {
            case null:
                return;
            case CardViewModel:
                CurrentPage = new CardView();
                break;
            case CustomerViewModel:
                CurrentPage = new CustomerView();
                break;
            case ProductViewModel:
                CurrentPage = new ProductView();
                break;
        }
        
        CurrentPage.BindingContext = viewModel; 
    }

    private async void UpdateTime()
    {
        await Task.Run(() =>
        {
            CurrentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        });
    }
}