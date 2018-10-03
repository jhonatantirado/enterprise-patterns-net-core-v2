using System;
using System.Collections.Generic;
using EnterprisePatterns.Api.Customers.Dto;

namespace EnterprisePatterns.Api.Customers.Application.Dto
{
    public class CustomerDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber {get; set;}
        public bool IsActive {get; set;}
        public string Status { get; set; }
        public string Email { get; set; }
        public DateTime? StatusExpirationDate { get; set; }
        public decimal MoneySpent { get; set; }
        public List<PurchasedMovieDto> PurchasedMovies { get; set; }

    }
}
