using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Storeii.Data;
using Storeii.Models;

namespace Storeii.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public IndexModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        public IList<Location> Location { get;set; }

        public async Task OnGetAsync()
        {
            Location = await _context.Location
                .Include(l => l.Driver_IdNavigation).ToListAsync();
        }
    }
}
