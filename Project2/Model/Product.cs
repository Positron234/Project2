using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public interface IProduct
    {
         int ID { get; set; }
         string Products { get; set; }
          DateTime DateStart { get; set; }
          int Srok { get; set; }
    }
    
    public class Product: IProduct
    {
        [Key]
        public int ID { get; set; }
        public string Products { get; set; }
        public DateTime DateStart { get; set; }
        public int Srok { get; set; }
        
    }
    
}
