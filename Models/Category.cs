using System.ComponentModel.DataAnnotations;

namespace Zad8.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }

        public ICollection<Commodity>? Commodities { get; set; }
    }
}
