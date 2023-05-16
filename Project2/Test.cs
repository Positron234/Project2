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
            prod.DateStart = new DateTime(2023, 1, 1);
            prod.Srok = 0;
            prod.Products = " ";
            DataService dataService = new DataService();
            Assert.AreEqual("Сделано!", dataService.CreateProduct(prod));
        }
        [TestCase]
        public void AddtoBase2()
        {
            Product prod = new Product();
            prod.DateStart = new DateTime(2023, 1, 1);
            prod.Srok = 0;
            prod.Products = " ";
            DataService dataService = new DataService();
            Assert.AreEqual("Уже существует", dataService.CreateProduct(prod));
        }
        [TestCase]
        public void DeletetoBase()
        {
            Product prod = new Product();
            prod.DateStart = new DateTime(2023, 1, 1);
            prod.Srok = 0;
            prod.Products = " ";
            DataService dataService = new DataService();
            Assert.AreEqual("Сделано!", dataService.DeleteProduct(prod));
        }
        [TestCase]
        public void DeletetoBase2()
        {
            Product prod = new Product();
            prod.DateStart = new DateTime(2023, 1, 1);
            prod.Srok = 0;
            prod.Products = " ";
            DataService dataService = new DataService();
            Assert.AreEqual("Такого продукта не существует", dataService.DeleteProduct(prod));
        }
    }
}
