﻿#nullable disable
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
    public class EditModel : PageModel
    {
        private readonly Zad8.Data.Warehouse _context;

        public EditModel(Zad8.Data.Warehouse context)
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
           ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "Name");
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

            _context.Attach(Commodity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommodityExists(Commodity.ID))
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

        private bool CommodityExists(int id)
        {
            return _context.Commodity.Any(e => e.ID == id);
        }
    }
}
