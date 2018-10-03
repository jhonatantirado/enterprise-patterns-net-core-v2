using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Movies.Domain.Entity;
using EnterprisePatterns.Api.Movies.Domain.Enum;
using System;
using System.Linq.Expressions;

namespace EnterprisePatterns.Api.Movies.Infrastructure.Persistence.NHibernate.Specification
{
    public sealed class MovieForKidsSpecification : Specification<Movie>
    {
        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.MpaaRating <= MpaaRating.PG;
        }
    }
}
