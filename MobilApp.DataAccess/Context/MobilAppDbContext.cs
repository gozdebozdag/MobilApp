using Microsoft.EntityFrameworkCore;
using MobilApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilApp.DataAccess.Context
{
    public class MobilAppDbContext:DbContext
    {
        public MobilAppDbContext(DbContextOptions<MobilAppDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
