namespace Radish.ViewModels
{
    /// <summary>
    /// This is the window to display dialog messages.
    /// </summary>
    public class ErrorWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// The view model constructor.
        /// </summary>
        /// <param name="errorTitle">The title of the error.</param>
        /// <param name="errorMessage">The error message.</param>
        public ErrorWindowViewModel(string errorTitle, string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.ErrorTitle = errorTitle;
        }

        /// <summary>
        /// The error message
        /// </summary>
        /// <value>The error message</value>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// The error title
        /// </summary>
        /// <value>The error title</value>
        public string ErrorTitle { get; private set; }
    }
}