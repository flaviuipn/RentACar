using System.Security.Policy;

namespace RentACar.Models
{
    public class CompanyIndexData
    {
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
