using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace RentACar.Models
{
    public class Rental
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? CarID { get; set; }
        public Car? Car {get; set; }
        [Display(Name = "Return date:")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
