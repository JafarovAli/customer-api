using AutoMapper;
using CustomerApi.Dtos;
using CustomerApi.Entites;

namespace CustomerApi.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, GetCustomerDto>().ReverseMap();
        CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
        CreateMap<Customer, CreateCustomerDto>().ReverseMap();
    }
}
