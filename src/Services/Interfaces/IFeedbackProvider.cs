using System;

namespace Services.Entities
{
    /// <summary>
    /// Will encapsulate all the functionality for giving the user some feedback on an ongoing process, such as generating
    /// the statistics for a given tree.
    /// </summary>
    public interface IFeedbackProvider
    {
        /// <summary>
        /// Event handler that gets triggered any time the Completed Proportion is changed.
        /// </summary>
        event EventHandler StateChanged;

        /// <summary>
        /// Checks whether this FP has reached the end of its current work.
        /// </summary>
        bool WorkCompleted { get; set; }

        /// <summary>
        /// The proportion (0 - 100) of work which has been done.
        /// </summary>
        double CompletedProportion { get; set; }

        /// <summary>
        /// Potential error message captured by a try-catch statement where the FP was present.
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Updates the error message and completes the current work.
        /// </summary>
        /// <param name="message"></param>
        void SetErrorMessage(string message);

        /// <summary>
        /// Updates the amount of work which has been done.
        /// </summary>
        /// <param name="value"></param>
        void UpdateCompletedProportion(double value);
    }
}