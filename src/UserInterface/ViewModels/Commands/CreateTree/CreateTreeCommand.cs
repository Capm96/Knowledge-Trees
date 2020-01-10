using System;
using System.Windows.Input;

namespace UserInterface.ViewModels.Commands.MainDashboard
{
    public class CreateTreeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        private CreateTreeViewModel _createNewTreeViewModel;

        public CreateTreeCommand(CreateTreeViewModel createNewTreeViewModel)
        {
            _createNewTreeViewModel = createNewTreeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _createNewTreeViewModel.CreateTreeButtonIsEnabled;
        }

        public void Execute(object parameter)
        {
            _createNewTreeViewModel.CreateNewTree();
        }
    }
}
