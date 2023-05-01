using Project.Model;
using Project2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.View
{
    public class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void NotifyPropertyChanged(
            string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public interface IProductsModel
    {
        ObservableCollection<Product> Products { get; set; }
        event EventHandler<ProjectEventArgs> ProductUpdated;
        void UpdateProducts(IProduct updatedProduct);
    }

    public class ProjectEventArgs : EventArgs
    {
        public IProduct Product { get; set; }
        public ProjectEventArgs(IProduct product)
        {
            Product = product;
        }
    }

    public class ProjectsModel : IProductsModel
    {
        public ObservableCollection<Product> Products { get; set; }
        public event EventHandler<ProjectEventArgs> ProductUpdated = delegate { };

        public ProjectsModel(IDataService dataService)
        {
            Products = new ObservableCollection<Product>();
            foreach (Product project in dataService.GetAllProducts())
            {
                Products.Add(project);
            }
        }

        public void UpdateProducts(IProduct updatedProject)
        {
            GetProject(updatedProject.ID).Update(updatedProject);
            ProductUpdated(this,
                new ProjectEventArgs(updatedProject));
        }

        private Product GetProject(int projectId)
        {
            return Products.FirstOrDefault(
                project => project.ID == projectId);
        }

    }
}
