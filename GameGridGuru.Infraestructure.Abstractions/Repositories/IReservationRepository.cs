using GameGridGuru.Domain.Models;

namespace GameGridGuru.Infraestructure.Abstractions.Repositories;

public interface IReservationRepository : IBaseRepository<Reservation>
{
    public Task<Reservation?> AddReservationAsync(Reservation reservation);
}