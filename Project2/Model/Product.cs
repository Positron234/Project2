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
        public int ID { get; set; }
        public string Products { get; set; }
         public DateTime DateStart { get; set; }
         public int Srok { get; set; }
    }
    
    public class Product: IProduct, INotifyPropertyChanged
    {
        [Key]
        public int ID { get; set; }
        public string Products { get; set; }
        public DateTime DateStart { get; set; }
        public int Srok { get; set; }
        public int id
        {
            get { return ID; }
            set
            {
                ID = value;
                OnPropertyChanged("ID");
            }
        }
        public string products
        {
            get { return Products; }
            set
            {
                Products = value;
                OnPropertyChanged("Products");
            }
        }
        public DateTime datestart
        {
            get { return DateStart; }
            set
            {
                DateStart = value;
                OnPropertyChanged("DateStart");
            }
        }
        public int srok
        {
            get { return Srok; }
            set
            {
                Srok = value;
                OnPropertyChanged("Srok");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    
}
