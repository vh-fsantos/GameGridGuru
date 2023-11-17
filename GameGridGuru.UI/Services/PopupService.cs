using CommunityToolkit.Maui.Views;
using GameGridGuru.UI.Abstractions.Services;

namespace GameGridGuru.UI.Services;

public class PopupService : IPopupService
{
    private Page MainPage => Application.Current?.MainPage ?? throw new NullReferenceException("Main page not found!");

    public async Task<object> ShowPopupAsync(Popup popup) 
        => await MainPage.ShowPopupAsync(popup);

    public async Task<bool> ShowConfirmationDialog(string title, string message) 
        => await MainPage.DisplayAlert(title, message, "Sim", "Não");
}