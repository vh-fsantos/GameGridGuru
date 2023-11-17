using System.Collections.ObjectModel;
using GameGridGuru.Domain.Models;
using GameGridGuru.UI.Abstractions.ViewModels;

namespace GameGridGuru.UI.ViewModels.HandlersViewModel;

public class HandlerCardViewModel: BaseViewModel, IHandlerViewModel
{
    private ObservableCollection<Customer> _customers;
    private string _customerPhoneNumber;
    private int _customerId;

    public HandlerCardViewModel(IEnumerable<Customer> customers)
    {
        Customers = new ObservableCollection<Customer>(customers);
    }

    public ObservableCollection<Customer> Customers
    {
        get => _customers;
        set
        {
            _customers = value;
            OnPropertyChanged(nameof(Customers));
        }
    }
}