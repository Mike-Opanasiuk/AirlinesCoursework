using Airlines.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Airlines
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
            Database.SetInitializer(new DbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flight>().HasOptional(f => f.Delay).WithRequired(d => d.Flight);
        }

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<BusinessTicket> BusinessTickets { get; set; }
        public virtual DbSet<StandartTicket> StandartTickets { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Delay> Delays { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
    }
}