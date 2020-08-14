using Services.Entities;
using System;

namespace Services
{
    public class FeedbackProvider : IFeedbackProvider
    {
        #region Fields & Properties

        public event EventHandler StateChanged;

        public bool WorkCompleted { get; set; }
        public double CompletedProportion { get; set; }
        public string ErrorMessage { get; set; }

        #endregion

        #region Constructors

        public FeedbackProvider()
        {

        }

        #endregion

        #region Methods

        public void SetErrorMessage(string message)
        {
            ErrorMessage = message;
            WorkCompleted = true;
            OnStateChanged();
        }

        public void UpdateCompletedProportion(double value)
        {
            CompletedProportion = value;
            WorkCompleted = value == 1d;
            OnStateChanged();
        }

        private void OnStateChanged()
        {
            var handler = StateChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
