using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}
