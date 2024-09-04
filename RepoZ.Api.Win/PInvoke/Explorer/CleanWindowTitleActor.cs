using System;

namespace RepoZ.Api.Win.PInvoke.Explorer
{
    public class CleanWindowTitleActor : ExplorerWindowActor
    {
        protected override void Act(IntPtr hwnd, string explorerLocationUrl)
        {
            Console.WriteLine("Clean " + explorerLocationUrl);
            string separator = "  [";
            WindowHelper.RemoveAppendedWindowText(hwnd, separator);
        }
    }
}
