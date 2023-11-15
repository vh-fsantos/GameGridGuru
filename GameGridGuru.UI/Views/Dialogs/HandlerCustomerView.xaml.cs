using CommunityToolkit.Maui.Views;
using GameGridGuru.UI.ViewModels.HandlersViewModel;

namespace GameGridGuru.UI.Views.Dialogs;

public partial class HandlerCustomerView : Popup
{
    public HandlerCustomerView()
    {
        InitializeComponent();
    }

    private void Button_OnClicked(object sender, EventArgs e)
    {
        var context = (HandlerCustomerViewModel) BindingContext;
        CloseAsync(context.GetCustomer());
    }
}