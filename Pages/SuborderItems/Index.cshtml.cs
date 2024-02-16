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
    public class IndexModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public IndexModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        public IList<Suborder_Items> Suborder_Items { get;set; }

        public async Task OnGetAsync()
        {
            Suborder_Items = await _context.Suborder_Items
                .Include(s => s.SubOrderId).ToListAsync();
        }
    }
}
