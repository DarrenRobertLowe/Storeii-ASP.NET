using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.CountiesInfo
{
    public class DeleteModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public DeleteModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Counties Counties { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Counties = await _context.Counties
                .Include(c => c.LocationId).FirstOrDefaultAsync(m => m.Id == id);

            if (Counties == null)
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

            Counties = await _context.Counties.FindAsync(id);

            if (Counties != null)
            {
                _context.Counties.Remove(Counties);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
