using CommunityToolkit.Maui.Views;

namespace GameGridGuru.UI.Views.Dialogs;

public partial class HandlerCardProductView : Popup
{
    public HandlerCardProductView()
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