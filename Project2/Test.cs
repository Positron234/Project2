using NUnit.Framework;
using Project.Model;
using Project2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestFixture]
    internal class Test
    {
        [TestCase]
        public void AddtoBase()
        {
            Product prod = new Product();
            prod.DateStart = DateTime.Now;
            prod.Srok = 0;
            prod.Products = " ";
            DataService dataService = new DataService();
            Assert.AreEqual("Сделано!", dataService.CreateProduct(prod));
        }
        [TestCase]
        public void DeletetoBase()
        {
            Product prod = new Product();
            prod.DateStart = DateTime.Now;
            prod.Srok = 0;
            prod.Products = " ";
            DataService dataService = new DataService();
            Assert.AreEqual("Сделано! Продукт " + prod.Products + " удален", dataService.DeleteProduct(prod));
        }
    }
}
