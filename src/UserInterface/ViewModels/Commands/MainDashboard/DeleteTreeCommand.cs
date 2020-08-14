using System;
using System.Windows.Input;

namespace UserInterface.ViewModels.Commands.MainDashboard
{
    public class DeleteTreeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        private MainDashboardViewModel _mainDashboardViewModel;

        public DeleteTreeCommand(MainDashboardViewModel mainDashboardViewModel)
        {
            _mainDashboardViewModel = mainDashboardViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _mainDashboardViewModel.SelectedTree != null;
        }

        public void Execute(object parameter)
        {
            _mainDashboardViewModel.DeleteTree();
        }
    }
}
