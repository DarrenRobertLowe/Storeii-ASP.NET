using Storeii.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Storeii.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
    }
}
