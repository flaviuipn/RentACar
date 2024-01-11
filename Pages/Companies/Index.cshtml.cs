using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Models;

namespace RentACar.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly RentACar.Data.RentACarContext _context;

        public IndexModel(RentACar.Data.RentACarContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; } = default!;

        public CompanyIndexData CompanyData { get; set; }
        public int CompanyID { get; set; }
        public int CarID { get; set; }

        public async Task OnGetAsync(int? id, int? carID)
        {
            CompanyData = new CompanyIndexData();
            CompanyData.Companies = await _context.Company
                .Include(i => i.Cars)
                .ThenInclude(c => c.CarCategories)
                .ThenInclude(c => c.Category)
                .OrderBy(i => i.CompanyName)
                .ToListAsync();

            if (id != null)
            {
                CompanyID = id.Value;
                Company company = CompanyData.Companies
                    .Where(i => i.ID == id.Value).Single();

                CompanyData.Cars = company.Cars;
            }
        }
    }
}
