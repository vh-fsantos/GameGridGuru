using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.Services.Abstractions.Services;

namespace GameGridGuru.Services.Services;

public class CardService : BaseService<Card>, ICardService
{
    private readonly ICardRepository _cardRepository;

    public CardService(ICardRepository baseRepository) : base(baseRepository)
    {
        _cardRepository = baseRepository;
    }

    public async Task<IEnumerable<Card>> GetAllCardsAsync()
        => await _cardRepository.GetAllCardsAsync();
}