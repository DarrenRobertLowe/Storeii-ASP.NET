using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.CartItems
{
    public class CreateModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public CreateModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Customer_Id"] = new SelectList(_context.Customer, "Id", "Id");
        ViewData["Product_Id"] = new SelectList(_context.Product, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CartItem CartItem { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CartItem.Add(CartItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
