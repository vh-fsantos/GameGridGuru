using System.Windows.Input;
using GameGridGuru.Domain.Models;
using GameGridGuru.UI.Abstractions.ViewModels;

namespace GameGridGuru.UI.ViewModels.HandlersViewModel;

public class HandlerCustomerViewModel : BaseViewModel, IHandlerViewModel
{
    private readonly MainViewModel _mainViewModel;
    private string _customerName;
    private string _customerPhoneNumber;
    
    public HandlerCustomerViewModel(MainViewModel mainViewModel, int customerId = 0)
    {
        _mainViewModel = mainViewModel;
        // SetCustomerCommand = new AsyncRelayCommand(SetCustomer);
    }

    public ICommand SetCustomerCommand { get; set; }

    public string CustomerName
    {
        get => _customerName;
        set
        {
            _customerName = value;
            OnPropertyChanged(nameof(CustomerName));
        }
    }

    public string CustomerPhoneNumber
    {
        get => _customerPhoneNumber;
        set
        {
            _customerPhoneNumber = value;
            OnPropertyChanged(nameof(CustomerPhoneNumber));
        }
    }
    // private async Task SetCustomer()
    // {
    //     var customer = new Customer
    //     {
    //         Name = CustomerName,
    //         PhoneNumber = CustomerPhoneNumber
    //     };
    //     await _mainViewModel.Repository.AddCustomerAsync(customer);
    // }
}