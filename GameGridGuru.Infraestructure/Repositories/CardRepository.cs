using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameGridGuru.Infraestructure.Repositories;

public class CardRepository : BaseRepository<Card>, ICardRepository
{
    public CardRepository(PostgresDbContext dbContext) : base(dbContext) { }
    
    public async Task<IEnumerable<Card>> GetAllCardsAsync()
    {
        try
        {
            return await GetDbSet().AsNoTracking()
                .Include(card => card.Customer)
                .Include(card => card.Reservation)
                .Include(card => card.Reservation.Court)
                .OrderByDescending(card => card.Id).ToListAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Get All Cards - {exception.Message}");
            return Enumerable.Empty<Card>();
        }
    }
}