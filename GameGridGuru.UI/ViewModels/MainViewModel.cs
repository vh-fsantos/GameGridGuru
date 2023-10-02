using CommunityToolkit.Maui.Views;
using GameGridGuru.Infraestructure.Repositories;
using GameGridGuru.UI.Abstractions.ViewModels;
using GameGridGuru.UI.Views;

namespace GameGridGuru.UI.ViewModels;

public class MainViewModel : BaseViewModel
{
    private List<IContextViewModel> _menuItems;
    private IContextViewModel _selectedItem;
    private View _currentPage;
    private readonly Page _mainPage;

    public MainViewModel(Page mainPage)
    {
        _menuItems = new List<IContextViewModel>
        {
            new CustomerViewModel(this),
            new ProductViewModel(this)
        };
        
        _mainPage = mainPage;
    }
    
    public Repository Repository = new();
    
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
    
    private void SetCurrentPage(IContextViewModel viewModel)
    {
        switch (viewModel)
        {
            case null:
                return;
            case CustomerViewModel:
                CurrentPage = new CustomerView();
                break;
            case ProductViewModel:
                CurrentPage = new ProductView();
                break;
        }
        
        CurrentPage.BindingContext = viewModel; 
    }

    public void ShowPopup(Popup popup)
    {
        _mainPage.ShowPopup(popup);
    }
}