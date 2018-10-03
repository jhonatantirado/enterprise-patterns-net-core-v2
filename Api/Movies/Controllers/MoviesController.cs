using EnterprisePatterns.Api.Common.Application;
using EnterprisePatterns.Api.Common.Application.Dto;
using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Movies.Application.Assembler;
using EnterprisePatterns.Api.Movies.Application.Dto;
using EnterprisePatterns.Api.Movies.Domain.Entity;
using EnterprisePatterns.Api.Movies.Domain.Repository;
using EnterprisePatterns.Api.Movies.Infrastructure.Persistence.NHibernate.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EnterprisePatterns.Api.Movies.Controllers
{
    [Route("v1/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMovieRepository _movieRepository;
        private readonly MovieAssembler _movieAssembler;

        public MoviesController(
            IUnitOfWork unitOfWork, 
            IMovieRepository movieRepository, 
            MovieAssembler movieAssembler)
        {
            _unitOfWork = unitOfWork;
            _movieRepository = movieRepository;
            _movieAssembler = movieAssembler;
        }

        [HttpGet]
        public IActionResult Movies([FromQuery]bool forKidsOnly, [FromQuery]bool onCD)
        {
            bool uowStatus = false;
            float minimumRating = 4;
            try
            {
                Specification<Movie> specification = GetMovieSpecification(forKidsOnly, onCD);
                uowStatus = _unitOfWork.BeginTransaction();
                List<Movie> movies = _movieRepository.GetList(specification, minimumRating);
                _unitOfWork.Commit(uowStatus);
                List<MovieDto> moviesDto = _movieAssembler.toDtoList(movies);
                return StatusCode(StatusCodes.Status200OK, moviesDto);
            } catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto("Internal Server Error"));
            }
        }

        private Specification<Movie> GetMovieSpecification(bool forKidsOnly, bool onCD)
        {
            Specification<Movie> specification = Specification<Movie>.All;
            
            if (forKidsOnly)
                specification = specification.And(new MovieForKidsSpecification());
            if (onCD)
                specification = specification.And(new AvailableOnCDSpecification());
            specification = specification.And(new MovieDirectedBySpecification("Bill Condon"));
            //spec = new MovieDirectedBySpecification("Marc Webb");
            return specification;
        }
    }
}
