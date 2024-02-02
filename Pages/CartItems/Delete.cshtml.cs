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
    public class DeleteModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public DeleteModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CartItem = await _context.CartItem.FindAsync(id);

            if (CartItem != null)
            {
                _context.CartItem.Remove(CartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
