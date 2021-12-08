using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomer();

        Task<Customer> GetCustomer(int customerId);

        Task<Customer> PostCustomer(Customer customer);

        Task<Customer> PutCustomer(int customerId, Customer newCustomer);

        Task<Customer> DeleteCustomer(int customerId);

        Task<bool> CustomerExists(int customerId);
        Task<int> CountCustomer();
    }
}
