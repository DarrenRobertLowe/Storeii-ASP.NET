using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public DetailsModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer
                .Include(c => c.AddressNavigation)
                .Include(c => c.LocationNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
