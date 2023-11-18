using System.Collections.ObjectModel;
using GameGridGuru.Domain.Models;
using GameGridGuru.UI.Abstractions.ViewModels;

namespace GameGridGuru.UI.ViewModels.HandlersViewModel;

public class HandlerCardViewModel: BaseViewModel, IHandlerViewModel
{
    private ObservableCollection<Customer> _customers;
    private ObservableCollection<Court> _courts;
    private DateTime _reservationStartDatetime;
    private DateTime _reservationEndDatetime;
    private Customer _selectedCustomer;
    private Court _selectedCourt;
    private float _courtValue;
    private bool _hasReservation;

    public HandlerCardViewModel(IEnumerable<Customer> customers, IEnumerable<Court> courts)
    {
        Customers = new ObservableCollection<Customer>(customers);
        Courts = new ObservableCollection<Court>(courts);
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

    public DateTime ReservationStartDateTime
    {
        get => _reservationStartDatetime;
        set
        {
            _reservationStartDatetime = value;
            UpdateCourtValue();
            OnPropertyChanged(nameof(ReservationStartDateTime));
        }
    }
    
    public DateTime ReservationEndDateTime
    {
        get => _reservationEndDatetime;
        set
        {
            _reservationEndDatetime = value;
            UpdateCourtValue();
            OnPropertyChanged(nameof(ReservationEndDateTime));
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
            Start = ReservationStartDateTime,
            End = ReservationEndDateTime,
            CourtId = SelectedCourt.Id
        };
    }

    private void UpdateCourtValue()
    {
        if (SelectedCourt == null)
            return;
        
        CourtValue = (float) ReservationEndDateTime.Subtract(ReservationStartDateTime).TotalHours * SelectedCourt.HourValue;
    }
}