using System;
using System.Linq.Expressions;

namespace EnterprisePatterns.Api.Common.Domain.Specification
{
    internal sealed class  IdentitySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}
