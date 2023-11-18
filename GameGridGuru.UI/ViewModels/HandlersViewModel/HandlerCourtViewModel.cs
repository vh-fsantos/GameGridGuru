using System.Globalization;
using GameGridGuru.Domain.Models;
using GameGridGuru.UI.Abstractions.ViewModels;

namespace GameGridGuru.UI.ViewModels.HandlersViewModel;

public class HandlerCourtViewModel : BaseViewModel, IHandlerViewModel
{
    private readonly CultureInfo _cultureInfo;
    private string _courtName;
    private string _courtHourValue;
    private int _courtId;

    public HandlerCourtViewModel()
    {
        _cultureInfo = new CultureInfo("pt-BR");
    }
    
    public HandlerCourtViewModel(Court product) : this()
    {
        CourtId = product.Id;
        CourtName = product.Name;
        CourtHourValue = product.HourValue.ToString(_cultureInfo);
    }

    public int CourtId
    {
        get => _courtId;
        set
        {
            _courtId = value;
            OnPropertyChanged(nameof(CourtId));
        }
    }
    
    public string CourtName
    {
        get => _courtName;
        set
        {
            _courtName = value;
            OnPropertyChanged(nameof(CourtName));
        }
    }

    public string CourtHourValue
    {
        get => _courtHourValue;
        set
        {
            _courtHourValue = value;
            OnPropertyChanged(nameof(CourtHourValue));
        }
    }

    public Court GetCourt()
    {
        try
        {
            if (!float.TryParse(CourtHourValue, _cultureInfo, out var value) || CourtHourValue.Contains('.'))
                return null;
            
            return new Court
            {
                Id = CourtId,
                Name = CourtName,
                HourValue = value
            };
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Exception trying to retrieve a court - {exception.Message}");
            return null;
        }
    }
}