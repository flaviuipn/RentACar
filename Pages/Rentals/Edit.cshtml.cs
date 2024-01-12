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
    public class EditModel : PageModel
    {
        private readonly RentACar.Data.RentACarContext _context;

        public EditModel(RentACar.Data.RentACarContext context)
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

            var rental =  await _context.Rentals.FirstOrDefaultAsync(m => m.ID == id);
            if (rental == null)
            {
                return NotFound();
            }
            Rental = rental;
           ViewData["CarID"] = new SelectList(_context.Car, "ID", "ID");
           ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Rental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalExists(Rental.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RentalExists(int id)
        {
          return (_context.Rentals?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
