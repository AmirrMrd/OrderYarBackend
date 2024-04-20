using Microsoft.EntityFrameworkCore;

namespace BarberShopProject.Infrastructure
{
    public class BarberShopContext : DbContext
    {
        public BarberShopContext(DbContextOptions<BarberShopContext> options)
        : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(b => b.Url)
                .IsRequired();
        }
        #endregion
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string? Url { get; set; }
    }
}
