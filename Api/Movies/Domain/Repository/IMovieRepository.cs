using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Movies.Domain.Entity;
using System.Collections.Generic;

namespace EnterprisePatterns.Api.Movies.Domain.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetList(
            Specification<Movie> specification,
            double minimumRating,
            int page = 0,
            int pageSize = 5);
        Movie Read(long id);
    }
}