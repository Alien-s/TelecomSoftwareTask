using System.Windows;

namespace TelecomSoftwareTask.Controller
{
    /// <summary>
    /// This Class shows the messages for errors
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Message for Incomming Data
        /// </summary>
        public void DataError()
        {
            MessageBox.Show("Could not to find file with Incomming Data or Data damaged", "Incomming Data Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Message for Error at serch field
        /// </summary>
        public void FilterError()
        {
            MessageBox.Show("Searching name is not exist at phone book", "Searching error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
