using EnterprisePatterns.Api.Common.Domain.ValueObject;
using System;
using System.Linq;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using EnterprisePatterns.Api.Movies.Domain.Entity;
using EnterprisePatterns.Api.Customers.Domain;
namespace EnterprisePatterns.Api.Customers
{
    public class Customer
    {
        public virtual long Id { get; set; }
        public virtual string IdentityDocument { get; set; }
        public virtual bool Active { get; set; }
        private string _firstName;
        private string _lastName;
        public virtual CustomerName FirstName 
        {             
            get => (CustomerName)_firstName;
            set => _firstName = value; 
        }
        public virtual CustomerName LastName 
        {             
            get => (CustomerName)_lastName;
            set => _lastName = value; 
        }
        private readonly string _email;
        public virtual Email Email => (Email)_email;
        public virtual CustomerStatus Status { get; protected set; }
        private decimal _moneySpent;
        public virtual Dollars MoneySpent
        {
            get => Dollars.Of(_moneySpent);
            protected set => _moneySpent = value;
        }

        private readonly IList<PurchasedMovie> _purchasedMovies;
        public virtual IReadOnlyList<PurchasedMovie> PurchasedMovies => _purchasedMovies.ToList();
        public Customer()
        {
            _purchasedMovies = new List<PurchasedMovie>();
        }
        public Customer(CustomerName firstName, Email email) : this()
        {
            _firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            _email = email ?? throw new ArgumentNullException(nameof(email));

            MoneySpent = Dollars.Of(0);
            Status = CustomerStatus.Regular;
        }

        public virtual bool HasPurchasedMovie(Movie movie)
        {
            return PurchasedMovies.Any(x => x.Movie == movie && !x.ExpirationDate.IsExpired);
        }

        public virtual void PurchaseMovie(Movie movie)
        {
            if (HasPurchasedMovie(movie))
                throw new Exception();

            ExpirationDate expirationDate = movie.GetExpirationDate();
            Dollars price = movie.CalculatePrice(Status);

            var purchasedMovie = new PurchasedMovie(movie, this, price, expirationDate);
            _purchasedMovies.Add(purchasedMovie);

            MoneySpent += price;
        }

        public virtual Result CanPromote()
        {
            if (Status.IsAdvanced)
                return Result.Fail("The customer already has the Advanced status");

            if (PurchasedMovies.Count(x =>
                x.ExpirationDate == ExpirationDate.Infinite || x.ExpirationDate.Date >= DateTime.UtcNow.AddDays(-30)) < 2)
                return Result.Fail("The customer has to have at least 2 active movies during the last 30 days");

            if (PurchasedMovies.Where(x => x.PurchaseDate > DateTime.UtcNow.AddYears(-1)).Sum(x => x.Price) < 100m)
                return Result.Fail("The customer has to have at least 100 dollars spent during the last year");

            return Result.Ok();
        }

        public virtual void Promote()
        {
            if (CanPromote().IsFailure)
                throw new Exception();

            Status = Status.Promote();
        }
    }
}
