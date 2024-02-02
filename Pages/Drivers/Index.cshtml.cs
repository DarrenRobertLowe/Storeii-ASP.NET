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
    public class IndexModel : PageModel
    {
        private readonly Storeii.Data.StoreiiContext _context;

        public IndexModel(Storeii.Data.StoreiiContext context)
        {
            _context = context;
        }

        public IList<Driver> Driver { get;set; }

        public async Task OnGetAsync()
        {
            Driver = await _context.Driver
                .Include(d => d.AddressNavigation).ToListAsync();
        }
    }
}
