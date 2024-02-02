using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.Drivers
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
        ViewData["Address"] = new SelectList(_context.Address, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Driver Driver { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Driver.Add(Driver);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
