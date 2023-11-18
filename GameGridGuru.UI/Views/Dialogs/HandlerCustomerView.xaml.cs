using CommunityToolkit.Maui.Views;
using GameGridGuru.UI.ViewModels.HandlersViewModel;

namespace GameGridGuru.UI.Views.Dialogs;

public partial class HandlerCustomerView : Popup
{
    public HandlerCustomerView()
    {
        InitializeComponent();
    }

    private void ButtonConfirm_OnClicked(object sender, EventArgs e)
    {
        var context = (HandlerCustomerViewModel) BindingContext;
        CloseAsync(context.GetCustomer());
    }
    
    private void ButtonCancel_OnClicked(object sender, EventArgs e)
    {
        CloseAsync();
    }
}