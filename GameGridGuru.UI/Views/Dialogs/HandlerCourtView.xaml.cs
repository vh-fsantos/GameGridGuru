using CommunityToolkit.Maui.Views;
using GameGridGuru.UI.ViewModels.HandlersViewModel;

namespace GameGridGuru.UI.Views.Dialogs;

public partial class HandlerCourtView : Popup
{
    public HandlerCourtView()
    {
        InitializeComponent();
    }

    private void Button_OnClicked(object sender, EventArgs e)
    {
        var context = (HandlerCourtViewModel) BindingContext;
        CloseAsync(context.GetCourt());
    }
}