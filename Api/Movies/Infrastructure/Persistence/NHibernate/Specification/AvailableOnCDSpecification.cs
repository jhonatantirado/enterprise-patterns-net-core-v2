using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Movies.Domain.Entity;
using System;
using System.Linq.Expressions;

namespace EnterprisePatterns.Api.Movies.Infrastructure.Persistence.NHibernate.Specification
{
    public sealed class AvailableOnCDSpecification : Specification<Movie>
    {
        private const int MonthsBeforeDVDIsOut = 6;

        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.ReleaseDate <= DateTime.Now.AddMonths(-MonthsBeforeDVDIsOut);
        }
    }
}
