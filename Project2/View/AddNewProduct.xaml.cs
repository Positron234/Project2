using Project2.Model;
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
using System.Windows.Shapes;

namespace Project2.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewProduct.xaml
    /// </summary>
    public partial class AddNewProduct : Window
    {
        private IProductsModel _productmodel;

        public AddNewProduct()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string product = name.Text;
            int srok = Convert.ToInt32(n2.Text);
            int day = Convert.ToInt32(n1.Text);
            int month = Convert.ToInt32(n3.Text);
            int year = Convert.ToInt32(n4.Text);
            DateTime date = new DateTime(year, month, day);
            _productmodel = new ProjectsModel(new DataService(), product,srok,date);
            DataContext = _productmodel;
            DialogResult = false;
        }
    }
}
