using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RentACar.Models
{
    public class Car
    {
        public int ID { get; set; }
        [Display(Name = "Car Name")]
        public string CarName { get; set; }
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }
        [Display(Name = "Fabrication Year")]
        public int Year { get; set; }
        public int? CompanyID { get; set; }
        public Company? Company { get; set; }

        public ICollection<CarCategory>? CarCategories { get; set; }

        [Column(TypeName = "decimal(6, 2)")] 
        public decimal Price { get; set; }

       

    }
}
