using System.ComponentModel.DataAnnotations;

namespace RentACar.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Category Name:")]
        public string CategoryName { get; set; }
        public ICollection<CarCategory>? CarCategories { get; set; }
    }
}
