using GameGridGuru.Domain.Models;

namespace GameGridGuru.Infraestructure.Abstractions.Repositories;

public interface ICardRepository : IBaseRepository<Card>
{
    public Task<IEnumerable<Card>> GetAllCardsAsync();
}