using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zad8.Models;
namespace Zad8.Pages.Categories
{
    public class ElementsOfCategoryModel : PageModel
    {
       private readonly Zad8.Data.Warehouse _context;
        public ElementsOfCategoryModel(Zad8.Data.Warehouse context)
        {
            _context = context; 
        }
        
        public List<Commodity> CommoditiesOfCategory = new List<Commodity>();
        public List<Category> Categories = new List<Category>();

        [BindProperty(SupportsGet =true)]
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category.ID = id;
            Category.Name = _context.Category.Where(c => c.ID == id).First().Name;
            Category.Description = _context.Category.Where(c => c.ID == id).First().Description;
            foreach (var comm in _context.Commodity)
            {
                if (comm.CategoryID == Category.ID)
                {
                    CommoditiesOfCategory.Add(comm);

                }
            }
        }
    }
}
