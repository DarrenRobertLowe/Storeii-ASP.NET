using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.Suppliers
{
    public class DetailsModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public DetailsModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        public Supplier Supplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Supplier = await _context.Supplier
                .Include(s => s.Address_IdNavigation)
                .Include(s => s.Location_IdNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Supplier == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
