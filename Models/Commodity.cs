using System.ComponentModel.DataAnnotations;

namespace Zad8.Models
{
    public class Commodity
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Nazwa towaru")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Cena")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Kategoria")]
        public int? CategoryID { get; set; }
        [Display(Name = "Kategoria")]
        public Category? Category { get; set; }
    }
}
