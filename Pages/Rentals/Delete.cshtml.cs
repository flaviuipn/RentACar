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
    public class DeleteModel : PageModel
    {
        private readonly RentACar.Data.RentACarContext _context;

        public DeleteModel(RentACar.Data.RentACarContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }
            var rental = await _context.Rentals.FindAsync(id);

            if (rental != null)
            {
                Rental = rental;
                _context.Rentals.Remove(Rental);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
