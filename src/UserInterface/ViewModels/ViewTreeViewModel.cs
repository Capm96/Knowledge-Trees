using Caliburn.Micro;
using Services.Constants;
using Services.Interfaces;
using System.Collections.ObjectModel;

namespace UserInterface.ViewModels
{
    public class ViewTreeViewModel : Screen
    {
        #region Fields & properties.

        private IFolderLogicHandler _folderLogicHandler;
        private IWordLogicHandler _wordLogicHandler;
        private MainDashboardViewModel _mainDashboardViewModel;

        private string _treeName;
        public string TreeName
        {
            get { return _treeName; }
            set { _treeName = value; }
        }

        private ObservableCollection<string> _leaves;

        private string _charCount;
        public string CharacterCount
        {
            get { return _charCount; }
            set 
            { 
                _charCount = value; 
                NotifyOfPropertyChange(() => CharacterCount);
            }
        }

        private string _wordCount;
        public string WordCount
        {
            get { return _wordCount; }
            set 
            { 
                _wordCount = value; 
                NotifyOfPropertyChange(() => WordCount);
            }
        }

        private string _leafCount;
        public string LeafCount
        {
            get { return _leafCount; }
            set 
            { 
                _leafCount = value;
                NotifyOfPropertyChange(() => LeafCount);
            }
        }

        private string _reportMessage;

        public string ReportMessage
        {
            get { return _reportMessage; }
            set 
            { 
                _reportMessage = value; 
                NotifyOfPropertyChange(() => ReportMessage);
            }
        }

        #endregion

        #region Constructors

        public ViewTreeViewModel(IFolderLogicHandler folderLogicHandler, IWordLogicHandler wordLogicHandler, MainDashboardViewModel mainDashboardViewModel, string selectedTree, ObservableCollection<string> leaves)
        {
            _folderLogicHandler = folderLogicHandler;
            _wordLogicHandler = wordLogicHandler;
            _mainDashboardViewModel = mainDashboardViewModel;
            TreeName = selectedTree;
            _leaves = leaves;
        }

        #endregion

        #region Methods
        public void UpdateStatistics()
        {
            var statistics = _wordLogicHandler.GetTotalTreeStatistics(TreeName);

            WordCount = (statistics[StatsNamingConstants.WordCount] - 1).ToString();
            LeafCount = statistics[StatsNamingConstants.LeafCount].ToString();
            CharacterCount = (statistics[StatsNamingConstants.CharacterCount] - 1).ToString();

            ReportMessage = $"You have written {CharacterCount} characters in {WordCount} words across {LeafCount} leaves!";
        }

        #endregion
    }
}
