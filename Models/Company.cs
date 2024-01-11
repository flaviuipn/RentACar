namespace RentACar.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        
        public string CompanyNumber { get; set; }

        public string CompanyEmail { get; set; }

        public ICollection<Car>? Cars { get; set; }
    }
}
