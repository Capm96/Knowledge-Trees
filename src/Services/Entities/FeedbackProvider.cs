using Services.Entities;
using System;

namespace Services
{
    public class FeedbackProvider : IFeedbackProvider
    {
        public event EventHandler StateChanged;

        public bool WorkCompleted { get; set; }
        public double CompletedProportion { get; set; }
        public string ErrorMessage { get; set; }

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
    }
}
