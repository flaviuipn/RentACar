using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Models;

namespace RentACar.Pages.Rentals
{
    public class DetailsModel : PageModel
    {
        private readonly RentACar.Data.RentACarContext _context;

        public DetailsModel(RentACar.Data.RentACarContext context)
        {
            _context = context;
        }

      public Rental Rental { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals.FirstOrDefaultAsync(m => m.ID == id);
            if (rental == null)
            {
                return NotFound();
            }
            else 
            {
                Rental = rental;
            }
            return Page();
        }
    }
}
