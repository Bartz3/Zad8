#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zad8.Data;
using Zad8.Models;

namespace Zad8.Pages.Commodities
{
    public class CreateModel : PageModel
    {
        private readonly Zad8.Data.Warehouse _context;

        public CreateModel(Zad8.Data.Warehouse context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Commodity Commodity { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Commodity.Add(Commodity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
