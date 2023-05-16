using Project.Model;
using ProjectBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Model
{
    public interface IDataService
    {
        public  IList<Product> GetAllProducts();
        public string CreateProduct(Product prod);
        public string DeleteProduct(Product product);
    }
    internal class DataService:IDataService
    {
        public  IList<Product> GetAllProducts()
        {
            using DataServiceStub db = new();
            var result = db.Products.ToList();
            return result;
        }
        public string CreateProduct(Product prod)
        {
            string result = "Уже существует";
            using DataServiceStub db = new();
            //проверяем сущесвует ли отдел
            bool checkIsExist = db.Products.Any(el => el.Products == prod.Products);
            if (!checkIsExist)
            {
                
                db.Products.Add(prod);
                db.SaveChanges();
                result = "Сделано!";
            }
            return result;
        }
        public string DeleteProduct(Product product)
        {
            string result = "Такого продукта не существует";
            using (DataServiceStub db = new())
            {
                db.Products.Remove(product);
                db.SaveChanges();
                result = "Сделано!";
            }
            return result;
        }
    }
}
