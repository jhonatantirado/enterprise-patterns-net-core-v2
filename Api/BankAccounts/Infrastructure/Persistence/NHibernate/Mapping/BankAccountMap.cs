using EnterprisePatterns.Api.BankAccounts.Domain.Entity;
using FluentNHibernate.Mapping;

namespace EnterprisePatterns.Api.BankAccounts.Infrastructure.Persistence.NHibernate.Mapping
{
    public class BankAccountMap : ClassMap<BankAccount>
    {
        public BankAccountMap()
        {
            Id(x => x.Id).Column("bank_account_id");
            Map(x => x.Number).Column("number");
            Component(x => x.Balance, m =>
            {
                m.Map(x => x.Amount, "balance");
                m.Map(x => x.Currency, "currency");
            });
            Map(x => x.Locked).CustomType<bool>().Column("locked");
            References(x => x.Customer, "customer_id");
        }
    }
}
