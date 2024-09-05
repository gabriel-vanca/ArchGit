using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Terminal.Gui;

namespace grrui.UI
{
<<<<<<< HEAD
	public static class TimelyMessage
	{
		public static void ShowMessage(string message, TimeSpan duration)
		{
			int width = message.Length + 6;
			int height = 5;
			int lines = Label.MeasureLines(message, width);
=======
    public static class TimelyMessage
    {
        public static void ShowMessage(string message, TimeSpan duration)
        {
            int width = message.Length + 6;
            int height = 5;
            //int lines = Label.MeasureLines(message, width);
>>>>>>> 4e2f094 (terminal fixed)

			var dialog = new Dialog(null, width, height);

			var label = new Label((width - 4 - message.Length) / 2, 0, message);
				dialog.Add(label);

			Task.Delay(duration).ContinueWith(t => dialog.Running = false);
			Application.Run(dialog);
			
		}
	}
}
