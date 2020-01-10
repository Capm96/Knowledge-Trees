using Caliburn.Micro;
using Services.Constants;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using UserInterface.ViewModels.Commands;

namespace UserInterface.ViewModels
{
    public class ViewTreeViewModel : Screen
    {
        #region Fields & properties.

        private IWordLogicHandler _wordLogicHandler;

        public ICommand UpdateStatisticsCommand { get; set; }

        private string _treeName;
        public string TreeName
        {
            get { return _treeName; }
            set 
            { 
                _treeName = value;
                NotifyOfPropertyChange(() => TreeName);
            }
        }

        private string _characterCount;
        public string CharacterCount
        {
            get { return _characterCount; }
            set 
            { 
                _characterCount = value; 
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

        private string _statisticsReportMessage;
        public string StatisticsReportMessage
        {
            get { return _statisticsReportMessage; }
            set 
            { 
                _statisticsReportMessage = value; 
                NotifyOfPropertyChange(() => StatisticsReportMessage);
            }
        }

        private string _loadingMessage;
        public string LoadingMessage
        {
            get { return _loadingMessage; }
            set 
            { 
                _loadingMessage = value;
                NotifyOfPropertyChange(() => LoadingMessage);
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

        public ViewTreeViewModel(IWordLogicHandler wordLogicHandler, string selectedTree)
        {
            _wordLogicHandler = wordLogicHandler;
            TreeName = selectedTree;
            StatsButtonEnabled = true;
            LoadingMessage = "";
            UpdateStatisticsCommand = new UpdateStatisticsCommand(this);
        }

        #endregion

        #region Methods

        public async void UpdateStatistics()
        {
            ModifyUIWhileUpdatingStatistics(true);

            var result = await Task.Run(() =>
            {
                var statistics = _wordLogicHandler.GetTotalTreeStatistics(TreeName);
                UpdateStatisticsProperties(statistics);
                return true;
            });

            ModifyUIWhileUpdatingStatistics(false);
        }

        private void UpdateStatisticsProperties(Dictionary<string, int> stats)
        {
            WordCount = (stats[StatsNamingConstants.WordCount] - 1).ToString();
            CharacterCount = (stats[StatsNamingConstants.CharacterCount] - 1).ToString();
            LeafCount = stats[StatsNamingConstants.LeafCount].ToString();

            StatisticsReportMessage = $"You have written {CharacterCount} characters in {WordCount} words across {LeafCount} leaves!";
        }

        private void ModifyUIWhileUpdatingStatistics(bool operationRunning)
        {
            if (operationRunning == true)
            {
                LoadingMessage = "Loading...";
                StatsButtonEnabled = false;
            }
            else
            {
                LoadingMessage = "";
                StatsButtonEnabled = true;
            }
        }

        #endregion
    }
}
