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
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;

namespace Project2.ViewModel
{
    public enum Status { None, Good, Bad }
    public interface IApplicationViewModel: IProduct
    {
        Status EstimateStatus { get; set; }
    }
    class ApplicationViewModel: IApplicationViewModel,INotifyPropertyChanged
    {
        private Status _estimateStatus = Status.None;
        private Product selectedProduct;
        private DataService db = new DataService();
        public AddNewProduct addNewProduct;
        private int id { get; set; }
        private string products { get; set; }
        private DateTime datestart { get; set; }
        private int srok { get; set; }
        public ObservableCollection<Product> Product { get; set; }
        private int month;
        private int year;
        private int day;
        private string name;
        private int time;
        private RelayCommand addCommand;
        #region Command
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
                            db.CreateProduct(prod);
                            addNewProduct.Close();
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
                      Product? prod = obj as Product;
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
                      month = 0;
                      year = 0;
                      day = 0;
                      name = "";
                      time = 0;
                      addNewProduct = new AddNewProduct(this);
                      addNewProduct.ShowDialog();
                  }));
            }
        }
        #endregion
        private Status UpdateEstimateStatus(Product prod)
        {
            TimeSpan day = new TimeSpan(prod.Srok, 0, 0, 0);
            if (prod.DateStart.Add(day) == DateTime.Now)
                _estimateStatus=Status.None;
            else if (prod.DateStart.Add(day) > DateTime.Now)
                _estimateStatus = Status.Good;
            else
                _estimateStatus = Status.Bad;
            return _estimateStatus;

        }
        #region Product sector
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public string Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged("Products");
            }
        }
        public DateTime DateStart
        {
            get { return datestart; }
            set
            {
                datestart = value;
                OnPropertyChanged("DateStart");
            }
        }
        public int Srok
        {
            get { return srok; }
            set
            {
                srok = value;
                OnPropertyChanged("Srok");
            }
        }
        #endregion 
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                EstimateStatus = UpdateEstimateStatus(selectedProduct);
                OnPropertyChanged("SelectedProduct");
            }
        }
        #region DateForm
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
        #endregion
        public ApplicationViewModel()
        {
            Product = new ObservableCollection<Product>(db.GetAllProducts());
        }
        public Status EstimateStatus
        {
            get { return _estimateStatus; }
            set
            {
                _estimateStatus = value;
                OnPropertyChanged("EstimateStatus");
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

