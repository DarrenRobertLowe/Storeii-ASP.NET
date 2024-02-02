using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.CartItems
{
    public class IndexModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public IndexModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        public IList<CartItem> CartItem { get;set; }

        public async Task OnGetAsync()
        {
            CartItem = await _context.CartItem
                .Include(c => c.Customer_IdNavigation)
                .Include(c => c.Product_IdNavigation).ToListAsync();
        }
    }
}
