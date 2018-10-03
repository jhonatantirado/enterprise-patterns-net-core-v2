namespace EnterprisePatterns.Api.Movies.Domain.Entity
{
    public class Director
    {
        public virtual long Id { get; protected set; }
        public virtual string IdentityDocument { get; }
        public virtual string Name { get; }
    }
}
