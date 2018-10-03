using AutoMapper;
using EnterprisePatterns.Api.Customers.Application.Dto;
using EnterprisePatterns.Api.Customers;

namespace EnterprisePatterns.Api.Customers.Application.Assembler
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(
                    dest => dest.FullName,
                    x => x.MapFrom(src => string.Concat(src.FirstName," ",src.LastName))
                )
                .ForMember(
                    dest => dest.DocumentNumber,
                    x => x.MapFrom(src => src.IdentityDocument)
                )
                .ForMember(
                    dest => dest.IsActive,
                    x => x.MapFrom(src => src.Active)
                );
        }
    }
}
