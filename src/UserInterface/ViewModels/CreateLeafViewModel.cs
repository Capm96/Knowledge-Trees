using Caliburn.Micro;
using Services.Constants;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using UserInterface.ViewModels.Commands;

namespace UserInterface.ViewModels
{
    public class CreateLeafViewModel : Screen, IDataErrorInfo
    {
        #region Fields & Properties

        IWordLogicHandler _wordLogicHandler;
        MainDashboardViewModel _mainDashboard;

        public ICommand CreateLeafCommand { get; set; }

        public string ParentTreeName { get; set; }

        private string _newLeafName;
        public string NewLeafName
        {
            get { return _newLeafName; }
            set
            {
                _newLeafName = value;
                NotifyOfPropertyChange(() => NewLeafName);
            }
        }

        private bool _createButtonIsEnabled;
        public bool CreateLeafButtonIsEnabled
        {
            get { return _createButtonIsEnabled; }
            set
            {
                _createButtonIsEnabled = value;
                NotifyOfPropertyChange(() => CreateLeafButtonIsEnabled);
            }
        }

        public string Error => throw new NotImplementedException();

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public string this[string name]
        {
            get
            {
                string result = null;

                // Will flag any strings that contain characters that are not mentioned below.
                Regex regex = new Regex(@"^[a-zA-Z0-9 ]*$");

                switch (name)
                {
                    case "NewLeafName":
                        if (string.IsNullOrWhiteSpace(NewLeafName))
                            result = "Leaf name cannot be empty.";
                        else if (LeafNameContainsInvalidCharacters())
                            result = "Please exclude any invalid characters.";
                        else if (LeafAlreadyExists())
                            result = "This leaf already exists.";
                        break;
                    default:
                        break;
                }

                // Adds potential error to error collection so that it can be displayed on the window.
                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                // If there are no errors at the moment, then button is enabled.
                CreateLeafButtonIsEnabled = String.IsNullOrWhiteSpace(ErrorCollection[name]);

                NotifyOfPropertyChange(() => ErrorCollection);
                return result;
            }
        }

        #endregion

        #region Constructors

        public CreateLeafViewModel(IWordLogicHandler wordLogicHandler, MainDashboardViewModel mainDashboard, string parentTreeName)
        {
            _wordLogicHandler = wordLogicHandler;
            _mainDashboard = mainDashboard;
            ParentTreeName = parentTreeName;
            CreateLeafCommand = new CreateLeafCommand(this);
        }

        #endregion

        #region Creating and validating methods.

        public void CreateNewLeaf()
        {
            // Get path.
            var leafPath = DirectoryConstants.CurrentWorkingPath + $@"\{ParentTreeName}" + $@"\{NewLeafName}.docx";

            // Create leaf & update main dashboard.
            _wordLogicHandler.CreateNewLeaf(leafPath, NewLeafName, ParentTreeName);
            _mainDashboard.UpdateLeavesList();

            TryClose();
        }

        private bool LeafNameContainsInvalidCharacters()
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9 ]*$");
            return regex.IsMatch(NewLeafName) == false;
        }

        private bool LeafAlreadyExists()
        {
            bool output = false;
            var potentialLeafName = NewLeafName.ToLower();

            foreach (var leaf in _mainDashboard.Leaves)
            {
                var existingLeafName = leaf.ToLower();
                if (existingLeafName.Equals(potentialLeafName))
                    output = true;
            }

            return output;
        }

        #endregion
    }
}
