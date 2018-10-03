using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Movies.Domain.Entity;
using System;
using System.Linq.Expressions;

namespace EnterprisePatterns.Api.Movies.Infrastructure.Persistence.NHibernate.Specification
{
    public sealed class MovieDirectedBySpecification : Specification<Movie>
    {
        private readonly string _director;

        public MovieDirectedBySpecification(string director)
        {
            _director = director;
        }

        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.Director.Name == _director;
        }
    }
}
