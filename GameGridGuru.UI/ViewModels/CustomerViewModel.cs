using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using GameGridGuru.Domain.InputModel;
using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.UI.Abstractions.Services;
using GameGridGuru.UI.Abstractions.ViewModels;
using GameGridGuru.UI.ViewModels.HandlersViewModel;
using GameGridGuru.UI.Views.Dialogs;
using Microsoft.Maui.Controls;

namespace GameGridGuru.UI.ViewModels;

public class CustomerViewModel : BaseViewModel, IContextViewModel
{
    private ObservableCollection<Customer> _customers;
    private Customer _selectedCustomer;
    
    public CustomerViewModel(IPopupService popupService, ICustomerRepository customerRepository, IMapper mapper)
    {
        AddCustomerCommand = new Command(AddCustomer);
        CustomerRepository = customerRepository;
        PopupService = popupService;
        Mapper = mapper;
        
        _ = LoadCustomersAsync();
    }
    
    private ICustomerRepository CustomerRepository  { get; }
    private IPopupService PopupService { get; }
    private IMapper Mapper { get; }
    public string Title => "Clientes";
    public ICommand AddCustomerCommand { get; set; }

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
            _ = EditCustomer();
            OnPropertyChanged(nameof(SelectedCustomer));
        }
    }

    private async Task LoadCustomersAsync()
    {
        Customers = new ObservableCollection<Customer>(await CustomerRepository.GetCustomersAsync());
    }
    
    private async void AddCustomer()
    {
        var context = new HandlerCustomerViewModel();
        var view = new HandlerCustomerView { BindingContext = context };
        var customerInfo = await PopupService.ShowPopupAsync(view);

        if (customerInfo is not CustomerInputModel customerInputModel) 
            return;

        var customer = new Customer();
        Mapper.Map(customerInputModel, customer);
        if (await CustomerRepository.AddCustomerAsync(customer))
            Customers.Add(customer);
    }
    
    private async Task EditCustomer()
    {
        if (SelectedCustomer == null) 
            return;
        
        var context = new HandlerCustomerViewModel(SelectedCustomer);
        var view = new HandlerCustomerView { BindingContext = context };
        var customerInfo = await PopupService.ShowPopupAsync(view);

        if (customerInfo is not CustomerInputModel customerInputModel) 
            return;
        
        Mapper.Map(customerInputModel, SelectedCustomer);
        if (await CustomerRepository.EditCustomerAsync(SelectedCustomer))
        {
            var customer = (await CustomerRepository.GetCustomerById(customerInputModel.Id))!;
            await LoadCustomersAsync();
        }
    }
}