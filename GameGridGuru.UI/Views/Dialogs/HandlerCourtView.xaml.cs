using CommunityToolkit.Maui.Views;

namespace GameGridGuru.UI.Views.Dialogs;

public partial class HandlerCourtView : Popup
{
    public HandlerCourtView()
    {
        InitializeComponent();
    }

    private void ButtonConfirm_OnClicked(object sender, EventArgs e)
    {
        CloseAsync(true);
    }
    
    private void ButtonCancel_OnClicked(object sender, EventArgs e)
    {
        CloseAsync();
    }
}