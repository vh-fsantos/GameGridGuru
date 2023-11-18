using CommunityToolkit.Maui.Views;
using GameGridGuru.UI.ViewModels.HandlersViewModel;

namespace GameGridGuru.UI.Views.Dialogs;

public partial class HandlerProductView : Popup
{
    public HandlerProductView()
    {
        InitializeComponent();
    }

    private void ButtonConfirm_OnClicked(object sender, EventArgs e)
    {
        var context = (HandlerProductViewModel) BindingContext;
        var product = context.GetProduct();
        if (product != null)
            CloseAsync(product);
    }

    private void ButtonCancel_OnClicked(object sender, EventArgs e)
    {
        CloseAsync();
    }
}