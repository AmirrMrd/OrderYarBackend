using BarberShop.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.DataLayer.Context
{
	public class BarberShopContext : DbContext
	{
        public BarberShopContext(DbContextOptions<BarberShopContext> options) : base(options)
        {
            
        }
        public DbSet<UserApplication> Users { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//One To One

			// One To Many
			modelBuilder.Entity<Customer>().HasMany(a => a.Orders).WithOne();
			modelBuilder.Entity<UserApplication>().HasMany(a => a.Orders).WithOne();

			base.OnModelCreating(modelBuilder);
		}
	}
}
