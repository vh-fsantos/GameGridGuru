using System.Collections.Generic;
using AutoMapper;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.Infraestructure.Repositories;
using GameGridGuru.UI.Abstractions.Services;
using GameGridGuru.UI.Abstractions.ViewModels;
using GameGridGuru.UI.Services;
using GameGridGuru.UI.Views;
using Microsoft.Maui.Controls;

namespace GameGridGuru.UI.ViewModels;

public class MainViewModel : BaseViewModel
{
    private List<IContextViewModel> _menuItems;
    private IContextViewModel _selectedItem;
    private View _currentPage;

    public MainViewModel(IPopupService popupService, ICustomerRepository customerRepository, IProductRepository productRepository, IMapper mapper)
    {
        _menuItems = new List<IContextViewModel>
        {
            new CustomerViewModel(popupService, customerRepository, mapper),
            new ProductViewModel(popupService, productRepository, mapper)
        };
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
}