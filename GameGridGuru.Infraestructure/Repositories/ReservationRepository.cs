using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;

namespace GameGridGuru.Infraestructure.Repositories;

public class ReservationRepository: BaseRepository<Reservation>, IReservationRepository
{
    public ReservationRepository(PostgresDbContext dbContext) : base(dbContext) { }

    public async Task<Reservation?> AddReservationAsync(Reservation reservation)
    {
        try
        {
            var entry = await GetDbSet().AddAsync(reservation);
            await SaveChangesAsync();
            return entry.Entity;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Exception while adding reservation {exception.Message}");
            return null;
        }
        finally
        {
            ClearChangeTracker();
        }
    }
}