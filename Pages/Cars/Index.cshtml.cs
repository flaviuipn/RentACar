using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Models;

namespace RentACar.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly RentACar.Data.RentACarContext _context;

        public IndexModel(RentACar.Data.RentACarContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; } = default!;

        public CarData CarD { get; set; }
        public int CarID { get; set; }
        public int CategoryID { get; set; }

        public string CarNameSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string
searchString)
        {
            CarD = new CarData();

            CarNameSort = String.IsNullOrEmpty(sortOrder) ? "carname_desc" : "";
            CurrentFilter = searchString;
            CarD.Cars = await _context.Car
                .Include(c => c.Company)  // Include or remove based on your actual relationships
                .Include(c => c.CarCategories)
                .ThenInclude(c => c.Category)
                .AsNoTracking()
                .OrderBy(c => c.CarName)
                .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                CarD.Cars = CarD.Cars.Where(s => s.CarName.Contains(searchString));

                if (id != null)
                {
                    CarID = id.Value;
                    Car car = CarD.Cars
                        .Where(i => i.ID == id.Value).Single();

                    CarD.Categories = car.CarCategories.Select(s => s.Category);
                }
                switch (sortOrder)
                {
                    case "carname_desc":
                        CarD.Cars = CarD.Cars.OrderByDescending(s =>
                       s.CarName);
                        break;

                    default:
                        CarD.Cars = CarD.Cars.OrderBy(s => s.CarName);
                        break;

                }
            }
        }
    }
}
