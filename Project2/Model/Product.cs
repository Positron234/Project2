using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public interface IProduct
    {
         string Name { get; set; }
         string DateStart { get; set; }
         string Srok { get; set; }
        void Update(IProduct product);
    }
    public class Product: IProduct
    {
        public string Name { get; set; }
        public string DateStart { get; set; }
        public string Srok { get; set; }
        public void Update(IProduct product)
        {
            Name = product.Name;
            DateStart = product.DateStart;
            Srok = product.Srok;
        }
    }
    
}
