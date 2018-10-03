using EnterprisePatterns.Api.BankAccounts.Domain.Entity;
using EnterprisePatterns.Api.BankAccounts.Domain.Repository;
using EnterprisePatterns.Api.Common.Infrastructure.Persistence.NHibernate;

namespace EnterprisePatterns.Api.Accounts.Infrastructure.Persistence.NHibernate.Repository
{
    public class BankAccountNHibernateRepository : BaseNHibernateRepository<BankAccount>, IBankAccountRepository
    {
        public BankAccountNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }
    }
}
