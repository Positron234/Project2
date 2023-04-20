using Project.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ProjectBilling.DataAccess
{
    public interface IDataService
    {
        IList<Product> Product();
    }

    public class DataServiceStub : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DataServiceStub()
        {
            Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(DESKTOP-C8L1TCD)\\mssqllocaldb;Database=SrokProduct;Trusted_Connection=True");
        }
    }
}
