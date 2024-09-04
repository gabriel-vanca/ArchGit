using RepoZ.Api.Common;
using System;
using System.Windows;

namespace RepoZ.App.Win
{
    internal class WpfThreadDispatcher : IThreadDispatcher
    {
        public void Invoke(Action act)
        {
            Application.Current?.Dispatcher.Invoke(act);
        }
    }
}