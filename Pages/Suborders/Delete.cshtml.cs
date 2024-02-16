using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.Suborders
{
    public class DeleteModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public DeleteModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Suborder Suborder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Suborder = await _context.Suborder
                .Include(s => s.OrderId)
                .Include(s => s.SupplierId).FirstOrDefaultAsync(m => m.Id == id);

            if (Suborder == null)
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

            Suborder = await _context.Suborder.FindAsync(id);

            if (Suborder != null)
            {
                _context.Suborder.Remove(Suborder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
