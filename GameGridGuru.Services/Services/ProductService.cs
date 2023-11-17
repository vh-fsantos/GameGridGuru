using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.Services.Abstractions.Services;

namespace GameGridGuru.Services.Services;

public class ProductService : BaseService<Product>, IProductService
{
    public ProductService(IProductRepository productRepository) : base(productRepository) { }
}