using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using GameGridGuru.Domain.Models;
using GameGridGuru.Services.Abstractions.Services;
using GameGridGuru.UI.Abstractions.Services;
using GameGridGuru.UI.Abstractions.ViewModels;
using GameGridGuru.UI.ViewModels.HandlersViewModel;
using GameGridGuru.UI.Views.Dialogs;

namespace GameGridGuru.UI.ViewModels;

public partial class CourtViewModel : BaseViewModel, IContextViewModel
{
    private ObservableCollection<Court> _court;
    private Court _selectedCourt;
    private bool _isCourtSelected;
    
    public CourtViewModel(IPopupService popupService, ICourtService courtService) : base(popupService)
    {
        CourtService = courtService;

        _ = LoadCourtsAsync();
    }
    
    private ICourtService CourtService { get; }
    
    public string Title => "Quadras";
    
    public ObservableCollection<Court> Courts
    {
        get => _court;
        set
        {
            _court = value;
            OnPropertyChanged(nameof(Courts));
        }
    }

    public Court SelectedCourt
    {
        get => _selectedCourt;
        set
        {
            _selectedCourt = value;
            IsCourtSelected = value != null;
            OnPropertyChanged(nameof(SelectedCourt));
        }
    }
    
    public bool IsCourtSelected
    {
        get => _isCourtSelected;
        set
        {
            _isCourtSelected = value;
            OnPropertyChanged(nameof(IsCourtSelected));
        }
    }
    
    private async Task LoadCourtsAsync()
    {
        Courts = new ObservableCollection<Court>(await CourtService.GetAllAsync());
    }
    
    [RelayCommand]
    private async Task AddCourt()
    {
        var context = new HandlerCourtViewModel();
        var view = new HandlerCourtView { BindingContext = context };
        var courtInfo = await PopupService!.ShowPopupAsync(view);

        if (courtInfo is not Court court) 
            return;
        
        if (await CourtService.AddEntityAsync(court))
            Courts.Add(court);
    }
    
    [RelayCommand]
    private async Task EditCourt()
    {
        if (SelectedCourt == null) 
            return;
        
        var context = new HandlerCourtViewModel(SelectedCourt);
        var view = new HandlerCourtView { BindingContext = context };
        var courtInfo = await PopupService!.ShowPopupAsync(view);

        if (courtInfo is not Court court) 
            return;
        
        if (await CourtService.EditEntityAsync(court))
            await LoadCourtsAsync();
    }
    
    [RelayCommand]
    private async Task DeleteCourt()
    {
        if (SelectedCourt == null || !await PopupService!.ShowConfirmationDialog("Atenção", "Você irá remover permanentemente esta quadra, tem certeza de que deseja continuar?")) 
            return;

        if (await CourtService.DeleteEntityAsync(SelectedCourt))
            await LoadCourtsAsync();
    }
}