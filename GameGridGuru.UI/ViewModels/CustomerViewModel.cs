using System.Collections.ObjectModel;
using System.Windows.Input;
using GameGridGuru.Domain.Models;
using GameGridGuru.UI.Abstractions.ViewModels;
using GameGridGuru.UI.ViewModels.HandlersViewModel;
using GameGridGuru.UI.Views.Dialogs;

namespace GameGridGuru.UI.ViewModels;

public class CustomerViewModel : BaseViewModel, IContextViewModel
{
    private readonly MainViewModel _mainViewModel;
    private ObservableCollection<Customer> _customers;
    
    public CustomerViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
        AddCustomerCommand = new Command(AddCustomer);
    }

    public string Title => "Clientes";
    public ICommand AddCustomerCommand { get; set; }

    private void AddCustomer()
    {
        var context = new HandlerCustomerViewModel(_mainViewModel);
        var view = new HandlerCustomerView { BindingContext = context };
        _mainViewModel.ShowPopup(view);
    }
}