using CommunityToolkit.Maui.Views;
using GameGridGuru.UI.Abstractions.Services;

namespace GameGridGuru.UI.Services;

public class PopupService : IPopupService
{
    public async Task<object> ShowPopupAsync(Popup popup)
    {
        var page = Application.Current?.MainPage ?? throw new NullReferenceException("Main page not found!");
        return await page.ShowPopupAsync(popup);
    }

    public async Task ClosePopup(Popup popup, object result)
    {
        await popup.CloseAsync(result);
    }
}