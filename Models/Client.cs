using System.ComponentModel.DataAnnotations;

namespace RentACar.Models
{
    public class Client
    {
        public int ID { get; set; }
        [Display(Name = "First Name:")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string? LastName { get; set; }
        public string? Adress { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Rental>? Rentals { get; set; }
    }
}
