using AutoMapper;

using CustomerProduct.Application.Features.Customers;
using CustomerProduct.Application.Features.Customers.Commands.Delete;
using CustomerProduct.Application.Features.Customers.Commands.DTOs;
using CustomerProduct.Application.Features.Customers.Commands.Update;
using CustomerProduct.Domain.Entities;

namespace CustomerProduct.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerListVm>().ReverseMap();
            CreateMap<Customer, CustomerDetailVm>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
        }
    }
}
