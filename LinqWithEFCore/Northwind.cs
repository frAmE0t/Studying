using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    public class Northwind :DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=.;" +
                "Initial Catalog=Northwind;" +
                "Integrated Security=true;" +
                "MultipleActiveResultSets=true;" +
                "TrustServerCertificate=true;";

            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(product => product.UnitPrice)
                .HasConversion<double>();
        }
    }
}
