using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GameGridGuru.Domain.Models;
using GameGridGuru.UI.Abstractions.ViewModels;
using GameGridGuru.UI.ViewModels.HandlersViewModel;
using GameGridGuru.UI.Views.Dialogs;
using Microsoft.Maui.Controls;

namespace GameGridGuru.UI.ViewModels;

public class CustomerViewModel : BaseViewModel, IContextViewModel
{
    private readonly MainViewModel _mainViewModel;
    private ObservableCollection<Customer> _customers;
    
    public CustomerViewModel(MainViewModel mainViewModel)
    {
        AddCustomerCommand = new Command(AddCustomer);
        _mainViewModel = mainViewModel;
        _customers = new ObservableCollection<Customer>(Task.Run(async () => await _mainViewModel.Repository.GetCustomersAsync()).GetAwaiter().GetResult());
    }

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

    private void AddCustomer()
    {
        var context = new HandlerCustomerViewModel(_mainViewModel);
        var view = new HandlerCustomerView { BindingContext = context };
        _mainViewModel.ShowPopup(view);
    }
}