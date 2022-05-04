#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zad8.Data;
using Zad8.Models;

namespace Zad8.Pages.Commodities
{
    public class DeleteModel : PageModel
    {
        private readonly Zad8.Data.Warehouse _context;

        public DeleteModel(Zad8.Data.Warehouse context)
        {
            _context = context;
        }

        [BindProperty]
        public Commodity Commodity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Commodity = await _context.Commodity
                .Include(c => c.Category).FirstOrDefaultAsync(m => m.ID == id);

            if (Commodity == null)
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

            Commodity = await _context.Commodity.FindAsync(id);

            if (Commodity != null)
            {
                _context.Commodity.Remove(Commodity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
