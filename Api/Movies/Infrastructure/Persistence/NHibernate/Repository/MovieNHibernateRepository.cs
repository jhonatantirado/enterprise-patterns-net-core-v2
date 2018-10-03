using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Common.Infrastructure.Persistence.NHibernate;
using EnterprisePatterns.Api.Movies.Domain.Entity;
using EnterprisePatterns.Api.Movies.Domain.Repository;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterprisePatterns.Api.Movies.Infrastructure.Persistence.NHibernate.Repository
{
    public class MovieNHibernateRepository : BaseNHibernateRepository<Movie>, IMovieRepository
    {
        public MovieNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public List<Movie> GetList(
            Specification<Movie> specification,
            double minimumRating,
            int page = 0,
            int pageSize = 5)
        {
            List<Movie> movies = new List<Movie>();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                movies = _unitOfWork.GetSession().Query<Movie>()
                    .Where(specification.ToExpression())
                    .Where(x => x.Rating >= minimumRating)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .Fetch(x => x.Director)
                    .ToList();
                _unitOfWork.Commit(uowStatus);
            } catch(Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return movies;
        }
    }
}
