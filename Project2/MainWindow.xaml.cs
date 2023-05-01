using Project2.Model;
using Project2.View;
using ProjectBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project2
{
    public partial class MainWindow : Window
    {
        private IProductsModel _productmodel; 
        public MainWindow()
        {
            InitializeComponent();
            _productmodel = new ProjectsModel(new DataService());
            DataContext = _productmodel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewProduct add = new AddNewProduct();
            add.Owner= this;
            add.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DeleteProdukt del = new DeleteProdukt();
            del.Owner= this;
            del.Show();
        }
    }
}
