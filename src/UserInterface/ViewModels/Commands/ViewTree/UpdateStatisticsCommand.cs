using System;
using System.Windows.Input;

namespace UserInterface.ViewModels.Commands.ViewTree
{
    public class UpdateStatisticsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        private ViewTreeViewModel _viewTreeViewModel;

        public UpdateStatisticsCommand(ViewTreeViewModel viewTreeViewModel)
        {
            _viewTreeViewModel = viewTreeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (_viewTreeViewModel.StatsButtonEnabled == true)
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            _viewTreeViewModel.UpdateStatistics();
        }
    }
}
