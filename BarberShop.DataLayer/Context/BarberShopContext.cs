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
			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}
			base.OnModelCreating(modelBuilder);
		}
	}
}
