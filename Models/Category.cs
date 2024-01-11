namespace RentACar.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<CarCategory>? CarCategories { get; set; }
    }
}
