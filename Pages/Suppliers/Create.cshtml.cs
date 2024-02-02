using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.Suppliers
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
        ViewData["Address_Id"] = new SelectList(_context.Address, "Id", "Id");
        ViewData["Location_Id"] = new SelectList(_context.Location, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Supplier Supplier { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Supplier.Add(Supplier);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
