using CommunityToolkit.Maui.Views;
using GameGridGuru.Domain.Models;
using GameGridGuru.UI.ViewModels.HandlersViewModel;

namespace GameGridGuru.UI.Views.Dialogs;

public partial class HandlerCardView : Popup
{
    public HandlerCardView()
    {
        InitializeComponent();
    }

    private void ButtonConfirm_OnClicked(object sender, EventArgs e)
    {
        try
        {
            var context = (HandlerCardViewModel) BindingContext;
            CloseAsync(new EntityId[] { context.GetCard(), context.GetReservation() });
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Erro closing Card Dialog - {exception.Message}");
        }
    }
    
    private void ButtonCancel_OnClicked(object sender, EventArgs e)
    {
        CloseAsync();
    }
}