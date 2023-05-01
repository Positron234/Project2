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
        public string CreateProduct(string name, int srok, DateTime date);
        public string DeleteProduct(Product product);
    }
    internal class DataService:IDataService
    {
        public  IList<Product> GetAllProducts()
        {
            using (DataServiceStub db = new DataServiceStub())
            {
                var result = db.Products.ToList();
                return result;
            }
        }
        public string CreateProduct(string name,int srok,DateTime date)
        {
            string result = "Уже существует";
            using (DataServiceStub db = new DataServiceStub())
            {
                //проверяем сущесвует ли отдел
                bool checkIsExist = db.Products.Any(el => el.Products == name);
                if (!checkIsExist)
                {
                    Product newProduct = new Product
                    {
                        Products = name,
                        Srok =srok,
                        DateStart=date
                    };
                    db.Products.Add(newProduct);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        public string DeleteProduct(Product product)
        {
            string result = "Такого продукта не существует";
            using (DataServiceStub db = new DataServiceStub())
            {
                db.Products.Remove(product);
                db.SaveChanges();
                result = "Сделано! Продукт " + product.Products + " удален";
            }
            return result;
        }
    }
}
