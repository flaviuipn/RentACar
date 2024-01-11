using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Models;

namespace RentACar.Data
{
    public class RentACarContext : DbContext
    {
        public RentACarContext (DbContextOptions<RentACarContext> options)
            : base(options)
        {
        }

        public DbSet<RentACar.Models.Car> Car { get; set; } = default!;

        public DbSet<RentACar.Models.Company>? Company { get; set; }

        public DbSet<RentACar.Models.Category>? Category { get; set; }

        
    }
}
