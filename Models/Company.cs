using System.ComponentModel.DataAnnotations;

namespace RentACar.Models
{
    public class Company
    {
        public int ID { get; set; }
        [Display(Name = "Company Name:")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Number:")]
        public string CompanyNumber { get; set; }

        [Display(Name = "Company Email:")]
        public string CompanyEmail { get; set; }

        public ICollection<Car>? Cars { get; set; }
    }
}
