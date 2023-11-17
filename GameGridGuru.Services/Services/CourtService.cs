using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.Services.Abstractions.Services;

namespace GameGridGuru.Services.Services;

public class CourtService: BaseService<Court>, ICourtService
{
    public CourtService(ICourtRepository customerRepository) : base(customerRepository) { }
}