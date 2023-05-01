using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public interface IProduct
    {
        public int ID { get; set; }
        public string Products { get; set; }
         public DateTime DateStart { get; set; }
         public int Srok { get; set; }
        public void Update(IProduct product);
    }
    public class Product: IProduct
    {
        public int ID { get; set; }
        public string Products { get; set; }
        public DateTime DateStart { get; set; }
        public int Srok { get; set; }
        public void Update(IProduct product)
        {
            Products = product.Products;
            DateStart = product.DateStart;
            Srok = product.Srok;
        }
    }
    
}
