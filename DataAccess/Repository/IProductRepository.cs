using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.DomainModel;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Task<Product> Add(Product product);

        Task<Product> Find(int id);

        Task<Product> Update(Product product);

        Task<Product> Remove(int id);

        Task<bool> IsExists(int id);
    }
}
