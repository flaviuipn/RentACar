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

        public DbSet<Rental> Rentals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Rental)
                .WithOne(r => r.Car)
                .HasForeignKey<Rental>(r => r.CarID);
        }
        public DbSet<RentACar.Models.Client>? Client { get; set; }
    }
}
