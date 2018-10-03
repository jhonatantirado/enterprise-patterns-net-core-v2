using EnterprisePatterns.Api.Common.Infrastructure.Persistence.NHibernate;
using EnterprisePatterns.Api.Movies.Domain.Entity;
using EnterprisePatterns.Api.Movies.Domain.Enum;
using FluentNHibernate.Mapping;
using FluentNHibernate;

namespace EnterprisePatterns.Api.Movies.Infrastructure.Persistence.NHibernate.Mapping
{
    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Id(x => x.Id).Column("movie_id");
            Map(x => x.Name).Column("movie_name");
            Map(x => x.ReleaseDate).Column("release_date");
            Map(x => x.MpaaRating).CustomType<int>().Column("mpaa_rating");
            Map(x => x.Genre).Column("genre");
            Map(x => x.Rating).Column("rating");
            References(x => x.Director);
            DiscriminateSubClassesOnColumn("LicensingModel");
            Map(Reveal.Member<Movie>("LicensingModel")).CustomType<int>();
        }
    }

    public class TwoDaysMovieMap : SubclassMap<TwoDaysMovie>
    {
        public TwoDaysMovieMap()
        {
            DiscriminatorValue(1);
        }
    }

    public class LifeLongMovieMap : SubclassMap<LifeLongMovie>
    {
        public LifeLongMovieMap()
        {
            DiscriminatorValue(2);
        }
    }
}
