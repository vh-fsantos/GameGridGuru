using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using GameGridGuru.Domain.Models;
using GameGridGuru.Services.Abstractions.Services;
using GameGridGuru.UI.Abstractions.Services;
using GameGridGuru.UI.Abstractions.ViewModels;
using GameGridGuru.UI.ViewModels.HandlersViewModel;
using GameGridGuru.UI.Views.Dialogs;

namespace GameGridGuru.UI.ViewModels;

public partial class CustomerViewModel : BaseViewModel, IContextViewModel
{
    private ObservableCollection<Customer> _customers;
    private Customer _selectedCustomer;
    
    public CustomerViewModel(IPopupService popupService, ICustomerService customerService)
    {
        CustomerService = customerService;
        PopupService = popupService;
        
        _ = LoadCustomersAsync();
    }
    
    private ICustomerService CustomerService  { get; }
    private IPopupService PopupService { get; }
    public string Title => "Clientes";

    public ObservableCollection<Customer> Customers
    {
        get => _customers;
        set
        {
            _customers = value;
            OnPropertyChanged(nameof(Customers));
        }
    }

    public Customer SelectedCustomer
    {
        get => _selectedCustomer;
        set
        {
            _selectedCustomer = value;
            OnPropertyChanged(nameof(SelectedCustomer));
        }
    }

    private async Task LoadCustomersAsync()
    {
        Customers = new ObservableCollection<Customer>(await CustomerService.GetCustomersAsync());
    }
    
    [RelayCommand]
    private async Task AddCustomer()
    {
        var context = new HandlerCustomerViewModel();
        var view = new HandlerCustomerView { BindingContext = context };
        var customerInfo = await PopupService.ShowPopupAsync(view);

        if (customerInfo is not Customer customer) 
            return;
        
        if (await CustomerService.AddCustomerAsync(customer))
            Customers.Add(customer);
    }
    
    [RelayCommand]
    private async Task EditCustomer()
    {
        if (SelectedCustomer == null) 
            return;
        
        var context = new HandlerCustomerViewModel(SelectedCustomer);
        var view = new HandlerCustomerView { BindingContext = context };
        var customerInfo = await PopupService.ShowPopupAsync(view);

        if (customerInfo is not Customer customer) 
            return;
        
        if (await CustomerService.EditCustomerAsync(customer))
            await LoadCustomersAsync();
    }
}