using EnterprisePatterns.Api.Customers;
using System.Collections.Generic;
using EnterprisePatterns.Api.Common.Domain.ValueObject;
namespace EnterprisePatterns.Api.Customers.Domain.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetList(int page = 0,int pageSize = 5);
        Customer GetByEmail(Email email);
        void Create (Customer customer);
        Customer Read(long id);
        
    }
    
}
