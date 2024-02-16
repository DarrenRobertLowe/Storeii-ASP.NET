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

namespace Storeii.Pages.SuborderItems
{
    public class EditModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public EditModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Suborder_Items Suborder_Items { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Suborder_Items = await _context.Suborder_Items
                .Include(s => s.SubOrderId).FirstOrDefaultAsync(m => m.Id == id);

            if (Suborder_Items == null)
            {
                return NotFound();
            }
           ViewData["SubOrder_Id"] = new SelectList(_context.Suborder, "Id", "Id");
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

            _context.Attach(Suborder_Items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Suborder_ItemsExists(Suborder_Items.Id))
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

        private bool Suborder_ItemsExists(int id)
        {
            return _context.Suborder_Items.Any(e => e.Id == id);
        }
    }
}
