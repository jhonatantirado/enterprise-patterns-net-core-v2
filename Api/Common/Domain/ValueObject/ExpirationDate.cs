using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace EnterprisePatterns.Api.Common.Domain.ValueObject
{
    public class ExpirationDate : CSharpFunctionalExtensions.ValueObject
    {
        public static readonly ExpirationDate Infinite = new ExpirationDate(null);

        public DateTime? Date { get; }

        public bool IsExpired => this != Infinite && Date < DateTime.UtcNow;

        private ExpirationDate(DateTime? date)
        {
            Date = date;
        }

        public static Result<ExpirationDate> Create(DateTime date)
        {
            return Result.Ok(new ExpirationDate(date));
        }

        protected bool EqualsCore(ExpirationDate other)
        {
            return Date == other.Date;
        }

        protected int GetHashCodeCore()
        {
            return Date.GetHashCode();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

        public static explicit operator ExpirationDate(DateTime? date)
        {
            if (date.HasValue)
                return Create(date.Value).Value;

            return Infinite;
        }

        public static implicit operator DateTime? (ExpirationDate date)
        {
            return date.Date;
        }
    }
}
