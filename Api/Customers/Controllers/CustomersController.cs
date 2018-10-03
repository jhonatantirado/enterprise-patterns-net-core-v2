using Microsoft.AspNetCore.Mvc;
using EnterprisePatterns.Api.Common.Application;
using EnterprisePatterns.Api.Customers.Domain.Repository;
using EnterprisePatterns.Api.Customers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using EnterprisePatterns.Api.Common.Application.Dto;
using EnterprisePatterns.Api.Customers.Application.Dto;
using EnterprisePatterns.Api.Customers.Application.Assembler;
using CSharpFunctionalExtensions;
using EnterprisePatterns.Api.Movies.Domain.Entity;
using EnterprisePatterns.Api.Movies.Domain.Repository;
using EnterprisePatterns.Api.Customers.Dto;
using EnterprisePatterns.Api.Movies.Application.Dto;
using EnterprisePatterns.Api.Common.Domain.ValueObject;
namespace EnterprisePatterns.Api.Controllers{
    [Route("v1/customers")]
    [ApiController]
    public class CustomersController: ControllerBase{
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerAssembler _customerAssembler;
        private readonly IMovieRepository _movieRepository;

        public CustomersController(IUnitOfWork unitOfWork, 
        ICustomerRepository customerRepository, 
        CustomerAssembler customerAssembler, 
        IMovieRepository movieRepository){
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _customerAssembler = customerAssembler;
            _movieRepository = movieRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(long id)
        {
            Customer customer = _customerRepository.Read(id);
            if (customer == null)
                return NotFound();
            
            var dto = new CustomerDto
            {
                Id = customer.Id,
                FullName = string.Concat(customer.FirstName.Value," ", customer.LastName.Value),
                Email = customer.Email.Value,
                MoneySpent = customer.MoneySpent,
                Status = customer.Status.Type.ToString(),
                StatusExpirationDate = customer.Status.ExpirationDate,
                PurchasedMovies = customer.PurchasedMovies.Select(x => new PurchasedMovieDto
                {
                    Price = x.Price,
                    ExpirationDate = x.ExpirationDate,
                    PurchaseDate = x.PurchaseDate,
                    Movie = new MovieDto
                    {
                        Id = x.Movie.Id,
                        Name = x.Movie.Name
                    }
                }).ToList()
            };

            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetList([FromQuery] int page = 0, [FromQuery] int size = 5){
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                List<Customer> customers = _customerRepository.GetList(page,size);
                _unitOfWork.Commit(uowStatus);
                List<CustomerDto> customersDto = _customerAssembler.toDtoList(customers);
                return StatusCode(StatusCodes.Status200OK, customersDto);
            } catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto("Internal Server Error"));
            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerDto item)
        {
            Result<CustomerName> customerNameOrError = CustomerName.Create(item.FullName);
            Result<Email> emailOrError = Email.Create(item.Email);

            Result result = Result.Combine(customerNameOrError, emailOrError);
            if (result.IsFailure)
                return BadRequest(result.Error);

            if (_customerRepository.GetByEmail(emailOrError.Value) != null)
                return BadRequest("Email is already in use: " + item.Email);

            var customer = new Customer(customerNameOrError.Value, emailOrError.Value);

            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                _customerRepository.Create(customer);
                _unitOfWork.Commit(uowStatus);
                return StatusCode(StatusCodes.Status200OK);
            } catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto("Internal Server Error"));
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(long id, [FromBody] UpdateCustomerDto item)
        {
            Result<CustomerName> customerNameOrError = CustomerName.Create(item.FirstName);
            if (customerNameOrError.IsFailure)
                return BadRequest(customerNameOrError.Error);

            Customer customer = _customerRepository.Read(id);
            if (customer == null)
                return BadRequest("Invalid customer id: " + id);

            customer.FirstName = customerNameOrError.Value;

            return Ok();
        }

        [HttpPost]
        [Route("{id}/movies")]
        public IActionResult PurchaseMovie(long id, [FromBody] long movieId)
        {
            Movie movie = _movieRepository.Read(movieId);
            if (movie == null)
                return BadRequest("Invalid movie id: " + movieId);

            Customer customer = _customerRepository.Read(id);
            if (customer == null)
                return BadRequest("Invalid customer id: " + id);

            if (customer.HasPurchasedMovie(movie))
                return BadRequest("The movie is already purchased: " + movie.Name);

            customer.PurchaseMovie(movie);

            return Ok();
        }

        [HttpPost]
        [Route("{id}/promotion")]
        public IActionResult PromoteCustomer(long id)
        {
            Customer customer = _customerRepository.Read(id);
            if (customer == null)
                return BadRequest("Invalid customer id: " + id);

            Result promotionCheck = customer.CanPromote();
            if (promotionCheck.IsFailure)
                return BadRequest(promotionCheck.Error);

            customer.Promote();

            return Ok();
        }

    }

}