using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.SuborderItems
{
    public class DetailsModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public DetailsModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
