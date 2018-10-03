using EnterprisePatterns.Api.Movies.Domain.Enum;
using EnterprisePatterns.Api.Common.Domain.ValueObject;
using System;

namespace EnterprisePatterns.Api.Movies.Domain.Entity
{
    public abstract class Movie
    {
        public virtual long Id { get; protected set; }
        public virtual string Name { get; }
        public virtual DateTime ReleaseDate { get; }
        public virtual MpaaRating MpaaRating { get; }
        public virtual string Genre { get; }
        public virtual double Rating { get; }
        public virtual Director Director { get; }
        public abstract ExpirationDate GetExpirationDate();
        protected virtual LicensingModel LicensingModel { get; set; }
        public virtual Dollars CalculatePrice(CustomerStatus status)
        {
            decimal modifier = 1 - status.GetDiscount();
            return GetBasePrice() * modifier;
        }

        protected abstract Dollars GetBasePrice();

        protected Movie()
        {
        }
    }
}
