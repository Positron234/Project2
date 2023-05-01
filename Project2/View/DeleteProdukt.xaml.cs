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
    /// Логика взаимодействия для DeleteProdukt.xaml
    /// </summary>
    public partial class DeleteProdukt : Window
    {
        private IProductsModel _productmodel;

        public DeleteProdukt()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string product = namee.Text;
            _productmodel = new ProjectsModel(new DataService(), product);
            DataContext = _productmodel;
            DialogResult = false;
        }
    }
}
