using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SalesWebMVCContext : DbContext
    {
        public SalesWebMVCContext (DbContextOptions<SalesWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Department>().HasData
        //        (
        //            new Department(1, "Computers"),
        //            new Department(2, "Electronics"),
        //            new Department(3, "Fashion"),
        //            new Department(4, "Books")
        //        );

        //    builder.Entity<Seller>().HasData
        //        (
        //            new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, new Department(1, "Computer")),
        //            new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, new Department(2, "Electronics"))
        //        );

        //    builder.Entity<SalesRecord>().HasData
        //        (
        //            new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, new Department(1, "Computer"))),
        //            new SalesRecord(2, new DateTime(2018, 09, 4), 7000.0, SaleStatus.Billed, new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, new Department(2, "Electronics")))
        //        );
        //}
    }
}
