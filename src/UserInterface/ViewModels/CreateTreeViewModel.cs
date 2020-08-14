using Caliburn.Micro;
using Services.Constants;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using UserInterface.ViewModels.Commands.CreateTree;

namespace UserInterface.ViewModels
{
    public class CreateTreeViewModel : Screen, IDataErrorInfo
    {
        #region Fields & Properties

        IFolderLogicHandler _folderLogicHandler;
        MainDashboardViewModel _mainDashboard;

        public ICommand CreateTreeCommand { get; set; }

        private string _newTreeName;
        public string NewTreeName
        {
            get { return _newTreeName; }
            set
            {
                _newTreeName = value;
                NotifyOfPropertyChange(() => NewTreeName);
            }
        }

        private bool _createButtonIsEnabled;
        public bool CreateTreeButtonIsEnabled
        {
            get { return _createButtonIsEnabled; }
            set
            {
                _createButtonIsEnabled = value;
                NotifyOfPropertyChange(() => CreateTreeButtonIsEnabled);
            }
        }

        public string Error => throw new NotImplementedException();
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public string this[string name]
        {
            get
            {
                string result = null;

                switch (name)
                {
                    case "NewTreeName":
                        if (string.IsNullOrWhiteSpace(NewTreeName))
                            result = "Tree name cannot be empty.";
                        else if (TreeNameContainsInvalidCharacters())
                            result = "Please exclude any invalid characters.";
                        else if (TreeAlreadyExists())
                            result = "This tree already exists.";
                        break;
                    default:
                        break;
                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                CreateTreeButtonIsEnabled = String.IsNullOrWhiteSpace(ErrorCollection[name]);

                NotifyOfPropertyChange(() => ErrorCollection);

                return result;
            }
        }

        #endregion

        #region Constructors

        public CreateTreeViewModel(IFolderLogicHandler folderLogicHandler, MainDashboardViewModel mainDashboard)
        {
            _folderLogicHandler = folderLogicHandler;
            _mainDashboard = mainDashboard;
            CreateTreeCommand = new CreateTreeCommand(this);
        }

        #endregion

        #region Creating & validating methods.

        public void CreateTree()
        {
            // Get path.
            var treePath = DirectoryConstants.CurrentWorkingPath + $@"\{NewTreeName}";

            // Create folder & update main dashboard.
            _folderLogicHandler.CreateNewTreeFolder(treePath);
            _mainDashboard.UpdateTreesList();

            TryClose();
        }

        private bool TreeNameContainsInvalidCharacters()
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9 ]*$");
            return regex.IsMatch(NewTreeName) == false;
        }

        private bool TreeAlreadyExists()
        {
            bool output = false;
            var potentialTreeName = NewTreeName.ToLower();

            foreach (var treeName in _mainDashboard.Trees)
            {
                var existingTreeName = treeName.ToLower();
                if (existingTreeName.Equals(potentialTreeName))
                    output = true;
            }

            return output;
        }

        #endregion
    }
}
