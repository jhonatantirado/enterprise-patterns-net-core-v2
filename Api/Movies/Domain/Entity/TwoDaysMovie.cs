using EnterprisePatterns.Api.Common.Domain.ValueObject;
using System;
namespace EnterprisePatterns.Api.Movies.Domain.Entity{
    public class TwoDaysMovie : Movie
    {
        public override ExpirationDate GetExpirationDate()
        {
            return (ExpirationDate)DateTime.UtcNow.AddDays(2);
        }

        protected override Dollars GetBasePrice()
        {
            return Dollars.Of(4);
        }
    }
}
