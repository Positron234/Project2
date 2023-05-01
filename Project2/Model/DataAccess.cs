using Project.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ProjectBilling.DataAccess
{

    public class DataServiceStub : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DataServiceStub()
        {
            Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SrokProduct;Trusted_Connection=True;");
        }
    }
}
