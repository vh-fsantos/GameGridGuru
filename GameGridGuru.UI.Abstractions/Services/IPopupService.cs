using CommunityToolkit.Maui.Views;

namespace GameGridGuru.UI.Abstractions.Services;

public interface IPopupService
{
    Task<object> ShowPopupAsync(Popup popup);

    Task<bool> ShowConfirmationDialog(string title, string message);
}