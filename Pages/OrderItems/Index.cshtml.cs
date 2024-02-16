using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.OrderItems
{
    public class IndexModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public IndexModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        public IList<OrderItem> OrderItem { get;set; }

        public async Task OnGetAsync()
        {
            OrderItem = await _context.OrderItems
                .Include(o => o.OrderId)
                .Include(o => o.ProductId).ToListAsync();
        }
    }
}
