using AutoMapper;
using GameGridGuru.Domain.InputModel;
using GameGridGuru.Domain.Models;

namespace GameGridGuru.UI.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CustomerInputModel, Customer>();
        CreateMap<Customer, CustomerInputModel>();
        CreateMap<ProductInputModel, Product>();
        CreateMap<Product, ProductInputModel>();
    }
}