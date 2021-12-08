using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.DomainModel;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShopContext _shopContext;

        public CustomerRepository(ShopContext shopContext)
        {
            this._shopContext = shopContext;
        }

        public  List<Customer> GetCustomer()
        {
            return _shopContext.Customer.ToList();
        }
    
        public async Task<Customer> GetCustomer(int customerId)
        {
            var result = await _shopContext.Customer.Include(x => x.Orders).SingleOrDefaultAsync(x => x.Id == customerId);
            return result;
        }

        public async Task<Customer> PostCustomer(Customer customer)
        {
            await _shopContext.Customer.AddAsync(customer);
            await _shopContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> PutCustomer(int customerId, Customer newCustomer)
        {
            _shopContext.Update(newCustomer);
            await _shopContext.SaveChangesAsync();
            return newCustomer;
        }

        public async Task<Customer> DeleteCustomer(int customerId)
        {
            var customer = await _shopContext.Customer.FindAsync(customerId);
            _shopContext.Customer.Remove(customer);
            await _shopContext.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> CustomerExists(int customerId)
        {
            var customer = await _shopContext.Customer.AnyAsync(x => x.Id == customerId);
            return customer;
        }
     
        public async Task<int> CountCustomer()
        {
            var count = await _shopContext.Customer.CountAsync();
            return count;
        }
    }
}
