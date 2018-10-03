using AutoMapper;
using EnterprisePatterns.Api.Movies.Application.Dto;
using EnterprisePatterns.Api.Movies.Domain.Entity;
using System.Collections.Generic;

namespace EnterprisePatterns.Api.Movies.Application.Assembler
{
    public class MovieAssembler
    {
        private readonly IMapper _mapper;

        public MovieAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<MovieDto> toDtoList(List<Movie> movieList)
        {
            return _mapper.Map<List<Movie>, List<MovieDto>>(movieList);
        }
    }
}