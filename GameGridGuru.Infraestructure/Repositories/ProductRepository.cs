using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;

namespace GameGridGuru.Infraestructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(PostgresDbContext dbContext) : base(dbContext) { }
}