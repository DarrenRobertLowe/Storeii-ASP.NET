using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.OrderItems
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
        ViewData["Orders_Id"] = new SelectList(_context.Set<Order>(), "Id", "Id");
        ViewData["Product_Id"] = new SelectList(_context.Product, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public OrderItem OrderItem { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderItems.Add(OrderItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
