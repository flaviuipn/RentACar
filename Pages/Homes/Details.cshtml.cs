﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Models;

namespace RentACar.Pages.Homes
{
    public class DetailsModel : PageModel
    {
        private readonly RentACar.Data.RentACarContext _context;

        public DetailsModel(RentACar.Data.RentACarContext context)
        {
            _context = context;
        }

      public Home Home { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Home == null)
            {
                return NotFound();
            }

            var home = await _context.Home.FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }
            else 
            {
                Home = home;
            }
            return Page();
        }
    }
}
