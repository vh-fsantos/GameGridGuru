using CommunityToolkit.Maui.Views;
using GameGridGuru.UI.ViewModels.HandlersViewModel;

namespace GameGridGuru.UI.Views.Dialogs;

public partial class HandlerCourtView : Popup
{
    public HandlerCourtView()
    {
        InitializeComponent();
    }

    private void ButtonConfirm_OnClicked(object sender, EventArgs e)
    {
        var context = (HandlerCourtViewModel) BindingContext;
        CloseAsync(context.GetCourt());
    }
    
    private void ButtonCancel_OnClicked(object sender, EventArgs e)
    {
        CloseAsync();
    }
}