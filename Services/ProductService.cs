using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Storeii.Data;
using Storeii.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Storeii.Services
{
    [Route("Products")]
    public class ProductService : IProductService
    {
        private readonly StoreiiContext _context;

        public ProductService(StoreiiContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id) =>
        await _context.Product.FindAsync(id);
    }
}
