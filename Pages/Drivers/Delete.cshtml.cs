using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.Drivers
{
    public class DeleteModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public DeleteModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Driver Driver { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver = await _context.Driver
                .Include(d => d.AddressNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Driver == null)
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

            Driver = await _context.Driver.FindAsync(id);

            if (Driver != null)
            {
                _context.Driver.Remove(Driver);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
