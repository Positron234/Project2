using ManageStaffDBApp.View;
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
    
    public interface IApplicationViewModel: IProduct
    {
        
    }
    class ApplicationViewModel: IApplicationViewModel,INotifyPropertyChanged
    {
        private Product selectedProduct;
        private DataService db = new DataService();
        public AddNewProduct addNewProduct;
        public MessageView messageView;
        private int id { get; set; }
        private string products { get; set; }
        private DateTime datestart { get; set; }
        private DateTime dateend { get; set; }
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
                            try
                            {
                                Product prod = new Product();
                                DateTime dt = new DateTime(year, month, day);
                                if(dt>DateTime.Now)
                                {
                                    throw new Exception("Неправильная дата");
                                }
                                prod.DateStart = dt;
                                if (string.IsNullOrEmpty(Name))
                                {
                                    throw new Exception("Введите имя");
                                }
                                    prod.Products = Name;
                                if(Time<=0)
                                {
                                    throw new Exception("Не правильный срок годности");
                                }
                                prod.Srok = Time;
                                Product.Insert(0, prod);
                                SelectedProduct = prod;
                                db.CreateProduct(prod);
                                addNewProduct.Close();
                            }
                            catch(Exception ex) 
                            {
                                MessageBox.Show(ex.Message,"Ошибка ввода",MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }));
                
                
            }
        }
        private RelayCommand checkCommand;
        public RelayCommand CheckCommand
        {
            get
            {
                return checkCommand ??
                  (checkCommand = new RelayCommand(obj =>
                  {
                      Product? prod = obj as Product;
                      if (DateEnd < DateTime.Now)
                      {
                          messageView = new MessageView(DateEnd.ToString()+" Просрочен!");
                      }
                      else
                      {
                          messageView = new MessageView(DateEnd.ToString() + " Годен!");
                      }
                      messageView.ShowDialog();
                  },
                 (obj) => Product.Count > 0));
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
                    OnPropertyChanged("SelectedProduct");
                if (selectedProduct != null)
                {
                    DateEnd = setend(selectedProduct);
                }
            }
        }
        DateTime setend(Product prod)
        {
            DateTime setend;
            TimeSpan day = new TimeSpan(prod.Srok, 0, 0, 0);
            setend = prod.DateStart.Add(day);
            return setend;
        }
        #region DateForm
        public int Month
        {
            get { return month; }
            set
            {
                
                month = value;
                if(month < 0&& month>12)
                {
                    throw new Exception("Не месяц");
                }
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
                if (day < 0 && day>31)
                {
                    throw new Exception("Не день");
                }
                OnPropertyChanged("Day");
            }
        }

        #endregion
        public DateTime DateEnd
        {
            get { return dateend; }
            set
            {
                dateend=value;
                OnPropertyChanged("DateEnd");
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

