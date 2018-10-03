using FluentNHibernate.Mapping;
using System;
using EnterprisePatterns.Api.Common.Domain.ValueObject;
namespace EnterprisePatterns.Api.Customers.Infrastructure.Persistence.NHibernate.Mapping
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id).Column("customer_id");
            Map(x => x.FirstName).Column("first_name").CustomType<CustomerName>();
            Map(x => x.LastName).Column("last_name").CustomType<CustomerName>();
            Map(x => x.IdentityDocument).Column("identity_document");
            Map(x => x.Active).CustomType<bool>().Column("active");
            Map(x => x.Email).CustomType<string>().Column("email").CustomType<Email>();
            Map(x => x.MoneySpent).CustomType<decimal>().Column("money_spent");
            Component(x => x.Status, y =>
            {
                y.Map(x => x.Type, "Status").CustomType<int>().Column("status");
                y.Map(x => x.ExpirationDate, "StatusExpirationDate").CustomType<DateTime?>()
                    .Column("expiration_date")
                    .Nullable();
            });

            HasMany(x => x.PurchasedMovies);
        }
    }
}
