namespace RentACar.Models
{
    public class CarCategory
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
