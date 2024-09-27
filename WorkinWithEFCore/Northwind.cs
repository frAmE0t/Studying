using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    public class Northwind : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=.;" +
                "Initial Catalog=Northwind;" +
                "MultipleActiveREsultSets=true;";

            optionsBuilder.UseSqlServer(connection);
        }
    }
}
