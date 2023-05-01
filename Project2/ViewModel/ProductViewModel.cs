using Project.Model;
using Project2.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.ViewModel
{
    public enum Status { None, Good, Bad };
    public interface IProductViewModel:IProduct
    {
       public Status EstimateStatus { get; set; }
    }
    public interface IProductsViewModel : INotifyPropertyChanged
    {
        public IProductViewModel SelectedProduct { get; set; }
        void UpdateProduct();
    }
    internal class ProductViewModel: Notifier, IProductViewModel 
    {
        private int _id;
        private string _Product;
        private DateTime _DateStart;
        private int _Srok;
        private Status _estimateStatus = Status.None;
        private void UpdateEstimateStatus()
        {
            TimeSpan day = new TimeSpan(_Srok,0,0,0);
            if (DateStart.Add(day) ==DateTime.Now)
                EstimateStatus = Status.None;
            else if (DateStart.Add(day) > DateTime.Now)
                EstimateStatus = Status.Good;
            else
                EstimateStatus = Status.Bad;
        }
        public ProductViewModel()
        {
        }
        public ProductViewModel(IProduct project)
        {
            if (project == null)
                return;
            ID = project.ID;
            Update(project);
        }

        public void Update(IProduct project)
        {
            ID= project.ID;
            Products = project.Products;
            DateStart = project.DateStart;
            Srok=project.Srok;

        }

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }
        public string Products
        {
            get { return _Product; }
            set
            {
                _Product = value;
                NotifyPropertyChanged("Products");
            }
        }
        public int Srok
        {
            get { return _Srok; }
            set
            {
                _Srok = value;
                NotifyPropertyChanged("Srok");
            }
        }
        public DateTime DateStart
        {
            get { return _DateStart; }
            set
            {
                _DateStart = value;
                NotifyPropertyChanged("DateStart");
            }
        }
        public Status EstimateStatus
        {
            get { return _estimateStatus; }
            set
            {
                _estimateStatus = value;
                NotifyPropertyChanged("EstimateStatus");
            }
        }
    }
}
