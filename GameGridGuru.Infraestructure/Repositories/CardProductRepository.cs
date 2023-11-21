using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;

namespace GameGridGuru.Infraestructure.Repositories;

public class CardProductRepository : BaseRepository<CardProduct>, ICardProductRepository
{
    public CardProductRepository(PostgresDbContext dbContext) : base(dbContext) { }
}