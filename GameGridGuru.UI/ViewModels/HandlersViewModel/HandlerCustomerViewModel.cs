using GameGridGuru.Domain.InputModel;
using GameGridGuru.Domain.Models;
using GameGridGuru.UI.Abstractions.ViewModels;

namespace GameGridGuru.UI.ViewModels.HandlersViewModel;

public class HandlerCustomerViewModel : BaseViewModel, IHandlerViewModel
{
    private string _customerName;
    private string _customerPhoneNumber;
    private int _customerId;

    public HandlerCustomerViewModel() { }
    
    public HandlerCustomerViewModel(Customer customer)
    {
        CustomerId = customer.Id;
        CustomerName = customer.Name;
        CustomerPhoneNumber = customer.PhoneNumber;
    }

    public int CustomerId
    {
        get => _customerId;
        set
        {
            _customerId = value;
            OnPropertyChanged(nameof(CustomerId));
        }
    }
    
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
}