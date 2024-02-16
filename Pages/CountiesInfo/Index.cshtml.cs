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
    public class IndexModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public IndexModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        public IList<Counties> Counties { get;set; }

        public async Task OnGetAsync()
        {
            Counties = await _context.Counties
                .Include(c => c.LocationId).ToListAsync();
        }
    }
}
