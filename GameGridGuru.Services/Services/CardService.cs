using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.Services.Abstractions.Services;

namespace GameGridGuru.Services.Services;

public class CardService : BaseService<Card>, ICardService
{
    public CardService(ICardRepository baseRepository) : base(baseRepository) { }
}