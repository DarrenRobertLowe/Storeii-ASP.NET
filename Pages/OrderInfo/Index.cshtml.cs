using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.OrderInfo
{
    public class IndexModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public IndexModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        public IList<Orders> Orders { get;set; }

        public async Task OnGetAsync()
        {
            Orders = await _context.Orders
                .Include(o => o.AddressId)
                .Include(o => o.CustomerId)
                .Include(o => o.DriverId)
                .Include(o => o.LocationId).ToListAsync();
        }
    }
}
