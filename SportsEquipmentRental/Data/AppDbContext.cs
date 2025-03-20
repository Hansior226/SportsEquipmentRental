using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

    public class AppDbContext : DbContext
    {
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RentalPlan> RentalPlans { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }