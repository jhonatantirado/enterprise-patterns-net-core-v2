using EnterprisePatterns.Api.BankAccounts.Domain.Entity;

namespace EnterprisePatterns.Api.BankAccounts.Domain.Repository
{
    public interface IBankAccountRepository
    {
        void Create(BankAccount bankAccount);
        void Delete(BankAccount bankAccount);
        BankAccount Read(long id);
    }
}
