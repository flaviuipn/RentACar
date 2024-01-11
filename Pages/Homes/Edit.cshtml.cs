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

namespace RentACar.Pages.Homes
{
    public class EditModel : PageModel
    {
        private readonly RentACar.Data.RentACarContext _context;

        public EditModel(RentACar.Data.RentACarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Home Home { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Home == null)
            {
                return NotFound();
            }

            var home =  await _context.Home.FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }
            Home = home;
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

            _context.Attach(Home).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeExists(Home.Id))
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

        private bool HomeExists(int id)
        {
          return (_context.Home?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
