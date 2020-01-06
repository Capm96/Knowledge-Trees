using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModels.Commands
{
    class OpenCreateNewTreeWindow : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly MainDashboardViewModel CallingViewModel;

        public OpenCreateNewTreeWindow(MainDashboardViewModel callingViewModel)
        {
            CallingViewModel = callingViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CallingViewModel.OpenCreateNewTreeWindow();
        }
    }
}
