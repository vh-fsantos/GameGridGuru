using System.Collections.ObjectModel;
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
    private bool _isCustomerSelected;
    
    public CustomerViewModel(IPopupService popupService, ICustomerService customerService) : base(popupService)
    {
        CustomerService = customerService;
        
        _ = LoadCustomersAsync();
    }
    
    private ICustomerService CustomerService  { get; }
    
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
            IsCustomerSelected = value != null;
            OnPropertyChanged(nameof(SelectedCustomer));
        }
    }

    public bool IsCustomerSelected
    {
        get => _isCustomerSelected;
        set
        {
            _isCustomerSelected = value;
            OnPropertyChanged(nameof(IsCustomerSelected));
        }
    }

    private async Task LoadCustomersAsync()
    {
        Customers = new ObservableCollection<Customer>(await CustomerService.GetAllAsync());
    }
    
    [RelayCommand]
    private async Task AddCustomer()
    {
        var context = new HandlerCustomerViewModel();
        var view = new HandlerCustomerView { BindingContext = context };
        var customerInfo = await PopupService!.ShowPopupAsync(view);

        if (customerInfo is not Customer customer) 
            return;
        
        if (await CustomerService.AddEntityAsync(customer))
            Customers.Add(customer);
    }
    
    [RelayCommand]
    private async Task EditCustomer()
    {
        if (SelectedCustomer == null) 
            return;
        
        var context = new HandlerCustomerViewModel(SelectedCustomer);
        var view = new HandlerCustomerView { BindingContext = context };
        var customerInfo = await PopupService!.ShowPopupAsync(view);

        if (customerInfo is not Customer customer) 
            return;
        
        if (await CustomerService.EditEntityAsync(customer))
            await LoadCustomersAsync();
    }

    [RelayCommand]
    private async Task DeleteCustomer()
    {
        if (SelectedCustomer == null || !await PopupService!.ShowConfirmationDialog("Atenção", "Você irá remover permanentemente este cliente, tem certeza de que deseja continuar?")) 
            return;

        if (await CustomerService.DeleteEntityAsync(SelectedCustomer))
            await LoadCustomersAsync();
    }
}