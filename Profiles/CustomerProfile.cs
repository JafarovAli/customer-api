using AutoMapper;
using CustomerApi.Dtos;
using CustomerApi.Entites;

namespace CustomerApi.Profiles;


public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerEntity, GetCustomerDto>().ReverseMap();
        CreateMap<CustomerEntity, UpdateCustomerDto>().ReverseMap();
        CreateMap<CustomerEntity, CreateCustomerDto>().ReverseMap();
    }
}
