using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.Services.Abstractions.Services;

namespace GameGridGuru.Services.Services;

public class ReservationService : BaseService<Reservation>, IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    
    public ReservationService(IReservationRepository baseRepository) : base(baseRepository)
    {
        _reservationRepository = baseRepository;
    }

    public async Task<Reservation?> AddReservationAsync(Reservation reservation)
        => await _reservationRepository.AddReservationAsync(reservation);
}