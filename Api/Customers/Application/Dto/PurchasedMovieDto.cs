using System;
using EnterprisePatterns.Api.Movies.Application.Dto;

namespace EnterprisePatterns.Api.Customers.Dto
{
    public class PurchasedMovieDto
    {
        public MovieDto Movie { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}