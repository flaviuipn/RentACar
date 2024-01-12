using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Models;

namespace RentACar.Pages.Rentals
{
    public class CreateModel : PageModel
    {
        private readonly RentACar.Data.RentACarContext _context;

        public CreateModel(RentACar.Data.RentACarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var carList = _context.Car.Include(c => c.Company).Select(x => new
            {
                x.ID, CarFullName = x.CarName + " - " + (x.Company != null ? x.Company.CompanyName : "Unknown Company")

            });



            ViewData["CarID"] = new SelectList(carList, "ID", "CarFullName");
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Rental Rental { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Rentals == null || Rental == null)
            {
                return Page();
            }

            _context.Rentals.Add(Rental);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
