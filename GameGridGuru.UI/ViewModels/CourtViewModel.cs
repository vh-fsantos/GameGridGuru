using System.Collections.ObjectModel;
using GameGridGuru.Domain.Models;
using GameGridGuru.Services.Abstractions.Services;
using GameGridGuru.UI.Abstractions.Services;
using GameGridGuru.UI.Abstractions.ViewModels;

namespace GameGridGuru.UI.ViewModels;

public class CourtViewModel : BaseViewModel, IContextViewModel
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
}