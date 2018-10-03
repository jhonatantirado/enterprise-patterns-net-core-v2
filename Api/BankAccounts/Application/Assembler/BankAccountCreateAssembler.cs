using AutoMapper;
using EnterprisePatterns.Api.BankAccounts.Application.Dto;
using EnterprisePatterns.Api.BankAccounts.Domain.Entity;

namespace EnterprisePatterns.Api.BankAccounts.Application.Assembler
{
    public class BankAccountCreateAssembler
    {
        private readonly IMapper _mapper;

        public BankAccountCreateAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public BankAccount toEntity(BankAccountCreateDto bankAccountCreateDto)
        {
            return _mapper.Map<BankAccount>(bankAccountCreateDto);
        }
    }
}
