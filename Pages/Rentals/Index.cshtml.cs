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
    public class IndexModel : PageModel
    {
        private readonly RentACar.Data.RentACarContext _context;

        public IndexModel(RentACar.Data.RentACarContext context)
        {
            _context = context;
        }

        public IList<Rental> Rental { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rentals != null)
            {
                Rental = await _context.Rentals
                .Include(r => r.Car)
                    .ThenInclude(r=>r.Company)
                .Include(r => r.Client).ToListAsync();
            }
        }
    }
}
