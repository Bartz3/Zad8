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

namespace Zad8.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Zad8.Data.Warehouse _context;

        public IndexModel(Zad8.Data.Warehouse context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
