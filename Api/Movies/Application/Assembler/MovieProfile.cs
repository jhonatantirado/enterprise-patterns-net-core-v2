using AutoMapper;
using EnterprisePatterns.Api.Movies.Application.Dto;
using EnterprisePatterns.Api.Movies.Domain.Entity;

namespace EnterprisePatterns.Api.BankAccounts.Application.Assembler
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(
                    dest => dest.Director,
                    x => x.MapFrom(src => src.Director.Name)
                )
                .ForMember(
                    dest => dest.MpaaRating,
                    x => x.MapFrom(src => src.MpaaRating.ToString())
                );
        }
    }
}
