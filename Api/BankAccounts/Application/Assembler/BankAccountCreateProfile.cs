using AutoMapper;
using EnterprisePatterns.Api.BankAccounts.Application.Dto;
using EnterprisePatterns.Api.BankAccounts.Domain.Entity;
using EnterprisePatterns.Api.Common.Domain.ValueObject;
using EnterprisePatterns.Api.Customers;

namespace EnterprisePatterns.Api.BankAccounts.Application.Assembler
{
    public class BankAccountCreateProfile : Profile
    {
        public BankAccountCreateProfile()
        {
            CreateMap<BankAccountCreateDto, BankAccount>()
                .ForMember(
                    dest => dest.Balance,
                    opts => opts.MapFrom(
                        src => new Money(src.Balance, src.Currency)
                    )
                )
                .ForMember(
                    dest => dest.Customer,
                    opts => opts.MapFrom(
                        src => new Customer
                        {
                            Id = src.CustomerId
                        }
                    )
                ).ReverseMap();
        }
    }
}
