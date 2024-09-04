using System.Windows;
using System.Windows.Controls;

namespace RepoZ.App.Win.Controls
{
    public class AcrylicContextMenu : ContextMenu
    {
        protected override void OnOpened(RoutedEventArgs e)
        {
            base.OnOpened(e);

            AcrylicHelper.EnableBlur(this);
        }

    }
}
