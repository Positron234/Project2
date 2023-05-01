using Project.Model;
using Project2.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project2.ViewModel
{
    public class ProductsViewModel : Notifier, IProductsViewModel
    {
        public const string SELECTED_PROJECT_PROPERRTY_NAME
            = "SelectedProject";

        private readonly IProductsModel _model;
        private IProductViewModel _selectedProducts;
        private Status _detailsEstimateStatus
            = Status.None;
        private bool _detailsEnabled;
        private readonly ICommand _updateCommand;


        public ObservableCollection<Product>
            Products
        { get { return _model.Products; } }

        public int? SelectedValue
        {
            set
            {
                if (value == null)
                    return;
                Product project = GetProduct((int)value);
                if (SelectedProduct == null)
                {
                    SelectedProduct
                        = new ProductViewModel(project);
                }
                else
                {
                    SelectedProduct.Update(project);
                }
                DetailsEstimateStatus =
                    SelectedProduct.EstimateStatus;
            }
        }

        public IProductViewModel SelectedProduct
        {
            get { return (IProductViewModel)_selectedProducts; }
            set
            {
                if (value == null)
                {
                    _selectedProducts = value;
                    DetailsEnabled = false;
                }
                else
                {
                    if (_selectedProducts == null)
                    {
                        _selectedProducts = new ProductViewModel(value);
                    }
                    _selectedProducts.Update(value);
                    DetailsEstimateStatus =_selectedProducts.EstimateStatus;
                    DetailsEnabled = true;
                    NotifyPropertyChanged(
                        SELECTED_PROJECT_PROPERRTY_NAME);
                }
            }
        }

        public Status DetailsEstimateStatus
        {
            get { return _detailsEstimateStatus; }
            set
            {
                _detailsEstimateStatus = value;
                NotifyPropertyChanged("DetailsEstimateStatus");
            }
        }

        public bool DetailsEnabled
        {
            get { return _detailsEnabled; }
            set
            {
                _detailsEnabled = value;
                NotifyPropertyChanged("DetailsEnabled");
            }
        }

        public ICommand UpdateCommand
        {
            get { return _updateCommand; }
        }

        public ProductsViewModel(IProductsModel projectModel)
        {
            _model = projectModel;
            _model.ProductUpdated +=
                model_ProjectUpdated;
            _updateCommand = new UpdateCommand(this);
        }

        public void UpdateProduct()
        {
            DetailsEstimateStatus =SelectedProduct.EstimateStatus;
            _model.UpdateProducts(SelectedProduct);
        }

        private void model_ProjectUpdated(object sender,
                                          ProjectEventArgs e)
        {
            GetProduct(e.Product.ID).Update(e.Product);
            if (SelectedProduct != null
                && e.Product.ID == SelectedProduct.ID)
            {
                SelectedProduct.Update(e.Product);
                DetailsEstimateStatus =
                    SelectedProduct.EstimateStatus;
            }
        }

        private Product GetProduct(int projectId)
        {
            return (from p in Products
                    where p.ID == projectId
                    select p).FirstOrDefault();
        }
    }
}
