#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zad8.Data;
using Zad8.Models;

namespace Zad8.Pages.Commodities
{
    public class IndexModel : PageModel
    {
        private readonly Zad8.Data.Warehouse _context;

        public IndexModel(Zad8.Data.Warehouse context)
        {
            _context = context;
        }

        public IList<Commodity> Commodity { get;set; }

        public async Task OnGetAsync()
        {
            ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "Name");
            Commodity = await _context.Commodity
                .Include(c => c.Category).ToListAsync();
        }
    }
}
