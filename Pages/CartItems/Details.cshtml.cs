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
    public class DetailsModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public DetailsModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        public CartItem CartItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CartItem = await _context.CartItem
                .Include(c => c.Customer_IdNavigation)
                .Include(c => c.Product_IdNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (CartItem == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
