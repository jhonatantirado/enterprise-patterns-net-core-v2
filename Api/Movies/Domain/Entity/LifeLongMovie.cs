using EnterprisePatterns.Api.Common.Domain.ValueObject;
using System;
namespace EnterprisePatterns.Api.Movies.Domain.Entity{
    public class LifeLongMovie : Movie
    {
        public override ExpirationDate GetExpirationDate()
        {
            return ExpirationDate.Infinite;
        }

        protected override Dollars GetBasePrice()
        {
            return Dollars.Of(8);
        }
    }
}
