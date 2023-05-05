using Project2.View;
using Project2.ViewModel;
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

namespace Project2.View
{

    public partial class MainWindow : Window
    {
        ApplicationViewModel applicationViewModel=new ApplicationViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = applicationViewModel;
        }
    }
}
