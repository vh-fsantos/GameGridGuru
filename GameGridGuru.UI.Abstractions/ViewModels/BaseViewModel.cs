using System.ComponentModel;
using GameGridGuru.UI.Abstractions.Services;

namespace GameGridGuru.UI.Abstractions.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    protected BaseViewModel () { }

    protected BaseViewModel(IPopupService popupService)
    {
        PopupService = popupService;
    }
 
    protected IPopupService? PopupService { get; }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    
    protected void OnPropertyChanged(string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}