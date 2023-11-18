using GameGridGuru.Domain.Models;

namespace GameGridGuru.Services.Abstractions.Services;

public interface IReservationService : IBaseService<Reservation>
{
    public Task<Reservation?> AddReservationAsync(Reservation reservation);
}