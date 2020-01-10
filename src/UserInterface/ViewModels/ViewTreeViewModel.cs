using Caliburn.Micro;
using Services;
using Services.Constants;
using Services.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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

        private double _completedProgressInGettingStatistics;

        public double CompletedProgressInGettingStatistics
        {
            get { return _completedProgressInGettingStatistics; }
            set 
            { 
                _completedProgressInGettingStatistics = value;
                NotifyOfPropertyChange(() => CompletedProgressInGettingStatistics);
            }
        }

        private string _loadingButtonEnabled;

        public string LoadingButtonEnabled
        {
            get { return _loadingButtonEnabled; }
            set 
            { 
                _loadingButtonEnabled = value;
                NotifyOfPropertyChange(() => LoadingButtonEnabled);
            }
        }

        private bool _statsButtonEnabled;

        public bool StatsButtonEnabled
        {
            get { return _statsButtonEnabled; }
            set
            { 
                _statsButtonEnabled = value;
                NotifyOfPropertyChange(() => StatsButtonEnabled);
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
            StatsButtonEnabled = true;
            LoadingButtonEnabled = "";
        }

        #endregion

        #region Methods
        public async void UpdateStatistics()
        {
            var feedbackProvider = new FeedbackProvider();

            CheckIfGeneratingStatistics(true);

            var result = await Task.Run(() =>
            {
                var statistics = _wordLogicHandler.GetTotalTreeStatistics(TreeName);
                UpdateStatisticsProperties(statistics);
                return true;
            });

            CheckIfGeneratingStatistics(false);
        }

        private void UpdateStatisticsProperties(Dictionary<string, int> stats)
        {
            WordCount = (stats[StatsNamingConstants.WordCount] - 1).ToString();
            CharacterCount = (stats[StatsNamingConstants.CharacterCount] - 1).ToString();
            LeafCount = stats[StatsNamingConstants.LeafCount].ToString();

            ReportMessage = $"You have written {CharacterCount} characters in {WordCount} words across {LeafCount} leaves!";
        }

        private void CheckIfGeneratingStatistics(bool operationRunning)
        {
            if (operationRunning == true)
            {
                LoadingButtonEnabled = "Loading...";
                StatsButtonEnabled = false;
            }
            else
            {
                LoadingButtonEnabled = "";
                StatsButtonEnabled = true;
            }
        }

        #endregion
    }
}
