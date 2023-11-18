using System.Collections.ObjectModel;
using GameGridGuru.Domain.Models;
using GameGridGuru.UI.Abstractions.ExtensionMethods;
using GameGridGuru.UI.Abstractions.ViewModels;

namespace GameGridGuru.UI.ViewModels.HandlersViewModel;

public class HandlerCardViewModel: BaseViewModel, IHandlerViewModel
{
    private ObservableCollection<Customer> _customers;
    private ObservableCollection<Court> _courts;
    private DateTime _limitDate;
    private DateTime _reservationStartDate;
    private DateTime _reservationEndDate;
    private TimeSpan _reservationStartTime;
    private TimeSpan _reservationEndTime;
    private Customer _selectedCustomer;
    private Court _selectedCourt;
    private float _courtValue;
    private bool _hasReservation;

    public HandlerCardViewModel(IEnumerable<Customer> customers, IEnumerable<Court> courts)
    {
        Customers = new ObservableCollection<Customer>(customers);
        Courts = new ObservableCollection<Court>(courts);
        LimitDate = DateTime.Today;
    }

    public ObservableCollection<Customer> Customers
    {
        get => _customers;
        set
        {
            _customers = value;
            OnPropertyChanged(nameof(Customers));
        }
    }

    public Customer SelectedCustomer
    {
        get => _selectedCustomer;
        set
        {
            _selectedCustomer = value;
            OnPropertyChanged(nameof(SelectedCustomer));
        }
    }
    
    public ObservableCollection<Court> Courts
    {
        get => _courts;
        set
        {
            _courts = value;
            OnPropertyChanged(nameof(Courts));
        }
    }

    public Court SelectedCourt
    {
        get => _selectedCourt;
        set
        {
            _selectedCourt = value;
            UpdateCourtValue();
            OnPropertyChanged(nameof(SelectedCourt));
        }
    }

    public DateTime LimitDate
    {
        get => _limitDate;
        set
        {
            _limitDate = value;
            UpdateCourtValue();
            OnPropertyChanged(nameof(LimitDate));
        }
    }
    
    public DateTime ReservationStartDate
    {
        get => _reservationStartDate;
        set
        {
            _reservationStartDate = value;
            UpdateCourtValue();
            OnPropertyChanged(nameof(ReservationStartDate));
        }
    }
    
    public DateTime ReservationEndDate
    {
        get => _reservationEndDate;
        set
        {
            _reservationEndDate = value;
            UpdateCourtValue();
            OnPropertyChanged(nameof(ReservationEndDate));
        }
    }

    public TimeSpan ReservationStartTime
    {
        get => _reservationStartTime;
        set
        {
            _reservationStartTime = value;
            UpdateCourtValue();
            OnPropertyChanged(nameof(ReservationStartTime));
        }
    }
    
    public TimeSpan ReservationEndTime
    {
        get => _reservationEndTime;
        set
        {
            _reservationEndTime = value;
            UpdateCourtValue();
            OnPropertyChanged(nameof(ReservationEndTime));
        }
    }

    public float CourtValue
    {
        get => _courtValue;
        set
        {
            _courtValue = value;
            OnPropertyChanged(nameof(CourtValue));
        }
    }

    public bool HasReservation
    {
        get => _hasReservation;
        set
        {
            _hasReservation = value;
            OnPropertyChanged(nameof(HasReservation));
        }
    }

    public Card GetCard()
    {
        return new Card
        {
            CustomerId = SelectedCustomer.Id,
            TotalValue = CourtValue
        };
    }

    public Reservation GetReservation()
    {
        if (!HasReservation)
            return null;

        return new Reservation
        {
            Start = ReservationStartDate.IncrementWithTime(ReservationStartTime),
            End = ReservationEndDate.IncrementWithTime(ReservationEndTime),
            CourtId = SelectedCourt.Id
        };
    }

    private void UpdateCourtValue()
    {
        if (SelectedCourt == null)
            return;

        var endDate = ReservationEndDate.IncrementWithTime(ReservationEndTime);
        var startDate = ReservationStartDate.IncrementWithTime(ReservationStartTime);
        
        CourtValue = (float) endDate.Subtract(startDate).TotalHours * SelectedCourt.HourValue;
    }
}