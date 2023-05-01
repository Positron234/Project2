using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project2.ViewModel
{
   

    internal class UpdateCommand : ICommand
    {
        private const int ARE_EQUAL = 0;
        private const int NONE_SELECTED = -1;
        private IProductsViewModel _vm;

        public UpdateCommand(IProductsViewModel viewModel)
        {
            _vm = viewModel;
            _vm.PropertyChanged += vm_PropertyChanged;
        }

        private void vm_PropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            if (string.Compare(e.PropertyName,
                               ProductsViewModel.
                               SELECTED_PROJECT_PROPERRTY_NAME)
                == ARE_EQUAL)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        public bool CanExecute(object parameter)
        {
            if (_vm.SelectedProduct == null)
                return false;
            return ((ProductViewModel)_vm.SelectedProduct).ID > NONE_SELECTED;
        }

        public event EventHandler CanExecuteChanged
            = delegate { };

        public void Execute(object parameter)
        {
            _vm.UpdateProduct();
        }
    }


}
