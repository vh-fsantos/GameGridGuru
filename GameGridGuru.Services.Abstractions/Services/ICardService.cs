using GameGridGuru.Domain.Models;

namespace GameGridGuru.Services.Abstractions.Services;

public interface ICardService : IBaseService<Card>
{
    public Task<IEnumerable<Card>> GetAllCardsAsync();
}