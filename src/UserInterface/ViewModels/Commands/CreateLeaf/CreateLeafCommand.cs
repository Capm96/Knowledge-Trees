using System;
using System.Windows.Input;

namespace UserInterface.ViewModels.Commands.CreateLeaf
{
    public class CreateLeafCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        private CreateLeafViewModel _createNewLeafViewModel;

        public CreateLeafCommand(CreateLeafViewModel createNewLeafViewModel)
        {
            _createNewLeafViewModel = createNewLeafViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _createNewLeafViewModel.CreateLeafButtonIsEnabled;
        }

        public void Execute(object parameter)
        {
            _createNewLeafViewModel.CreateLeaf();
        }
    }
}
