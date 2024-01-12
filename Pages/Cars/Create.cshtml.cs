using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.Data;
using RentACar.Models;

namespace RentACar.Pages.Cars
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : CarCategoriesPageModel
    {
        private readonly RentACar.Data.RentACarContext _context;

        public CreateModel(RentACar.Data.RentACarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CompanyID"] = new SelectList(_context.Set<Company>(), "ID",
"CompanyName");
            var car = new Car();
            car.CarCategories = new List<CarCategory>();
            PopulateAssignedCategoryData(_context, car);
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCar = new Car();

            if (selectedCategories != null)
            {
                newCar.CarCategories = new List<CarCategory>();

                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CarCategory
                    {
                        CategoryID = int.Parse(cat)
                    };

                    newCar.CarCategories.Add(catToAdd);
                }
            }

            Car.CarCategories = newCar.CarCategories;

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
