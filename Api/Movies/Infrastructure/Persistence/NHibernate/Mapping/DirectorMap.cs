using EnterprisePatterns.Api.Movies.Domain.Entity;
using FluentNHibernate.Mapping;

namespace EnterprisePatterns.Api.Movies.Infrastructure.Persistence.NHibernate.Mapping
{
    public class DirectorMap : ClassMap<Director>
    {
        public DirectorMap()
        {
            Id(x => x.Id).Column("director_id");
            Map(x => x.IdentityDocument).Column("identity_document");
            Map(x => x.Name).Column("director_name");
        }
    }
}
