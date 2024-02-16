using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.Suborders
{
    public class EditModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public EditModel(Storeii.Data.StoreiiContext context)
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
           ViewData["Order_Id"] = new SelectList(_context.Orders, "Id", "Id");
           ViewData["Supplier_Id"] = new SelectList(_context.Orders, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Suborder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuborderExists(Suborder.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SuborderExists(int id)
        {
            return _context.Suborder.Any(e => e.Id == id);
        }
    }
}
