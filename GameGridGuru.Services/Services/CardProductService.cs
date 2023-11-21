using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.Services.Abstractions.Services;

namespace GameGridGuru.Services.Services;

public class CardProductService : BaseService<CardProduct>, ICardProductService
{
    public CardProductService(ICardProductRepository baseRepository) : base(baseRepository) { }
}