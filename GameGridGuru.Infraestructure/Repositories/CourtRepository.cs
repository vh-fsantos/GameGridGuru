using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;

namespace GameGridGuru.Infraestructure.Repositories;

public class CourtRepository: BaseRepository<Court>, ICourtRepository
{
    public CourtRepository(PostgresDbContext dbContext) : base(dbContext) { }
}