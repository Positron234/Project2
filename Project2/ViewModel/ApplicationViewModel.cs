using Project.Model;
using Project2.Model;
using Project2.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project2.ViewModel
{
    class ApplicationViewModel:INotifyPropertyChanged
    {
        private Product selectedProduct;
        private DataService db = new DataService();
        public ObservableCollection<Product> Product { get; set; }
        private int month;
        private int year;
        private int day;
        private string name;
        private int time;
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        Product prod = new Product();
                        DateTime dt = new DateTime(year, month, day);
                        prod.DateStart = dt;
                        prod.Products = name;
                        prod.Srok = time;
                        Product.Insert(0, prod);
                        SelectedProduct = prod;
                        db.CreateProduct(prod.Products, prod.Srok,dt );
                    }));
            }
        }
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Product prod = obj as Product;
                      if (prod != null)
                      {
                          Product.Remove(prod);
                          db.DeleteProduct(prod);
                      }
                  },
                 (obj) => Product.Count > 0));
            }
        }
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                     AddNewProduct addNewProduct = new AddNewProduct(this);
                      addNewProduct.ShowDialog();
                  },
                 (obj) => Product.Count > 0));
            }
        }
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }
        public int Month
        {
            get { return month; }
            set
            {
                month = value;
                OnPropertyChanged("Month");
            }
        }
        public int Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }
        public int Day
        {
            get { return day; }
            set
            {
                day = value;
                OnPropertyChanged("Day");
            }
        }
        public ApplicationViewModel()
        {
            Product = new ObservableCollection<Product>(db.GetAllProducts());
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

