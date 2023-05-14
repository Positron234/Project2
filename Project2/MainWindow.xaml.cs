using Project2.ViewModel;
using System.Windows;


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
