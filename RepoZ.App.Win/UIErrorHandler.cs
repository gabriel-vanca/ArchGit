using RepoZ.Api.Common;
using System.Windows;

namespace RepoZ.App.Win
{
    public class UIErrorHandler : IErrorHandler
    {
        public void Handle(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
