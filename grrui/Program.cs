using grrui.Model;
using grrui.UI;
using RepoZ.Ipc;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Terminal.Gui;

namespace grrui
{
	class Program
	{
		private const int BUTTON_BORDER = 4; // 2 chars to the left, 2 to the right
		private const int BUTTON_DISTANCE = 1;

		private static IpcClient _client;
		private static ListView _repositoryList;
		private static RepositoriesView _repositoriesView;
		private static TextField _filterField;

<<<<<<< HEAD
		static void Main(string[] args)
		{
			_client = new IpcClient(new DefaultIpcEndpoint());
			var answer = _client.GetRepositories();
=======
        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("Waiting a few seconds for server to initialise and load the data...");
            System.Threading.Thread.Sleep(7000);
#endif
            _client = new IpcClient(new DefaultIpcEndpoint());
            var answer = _client.GetRepositories();
>>>>>>> 4e2f094 (terminal fixed)

			var repositoryCount = answer?.Repositories?.Length ?? 0;
			if (repositoryCount == 0)
			{
				if (!string.IsNullOrEmpty(answer?.Answer))
					Console.WriteLine(answer.Answer);
				else
					Console.WriteLine("No repositories yet");

				return;
			}

			_repositoriesView = new RepositoriesView(answer.Repositories);

			Application.Init();

<<<<<<< HEAD
			var filterLabel = new Label(1, 1, "Filter: ");
			_filterField = new TextField("")
			{
				X = Pos.Right(filterLabel) + 2,
				Y = Pos.Top(filterLabel),
				Width = Dim.Fill(margin: 1),
			};
			_filterField.Changed += FilterField_Changed;
=======
            var filterLabel = new Label(1, 1, "Filter: ");
            _filterField = new TextField("")
            {
                X = Pos.Right(filterLabel) + 2,
                Y = Pos.Top(filterLabel),
                Width = Dim.Fill(margin: 1),
            };
            _filterField.TextChanged += FilterField_Changed;
>>>>>>> 4e2f094 (terminal fixed)

			_repositoryList = new ListView(_repositoriesView.Repositories)
			{
				X = Pos.Left(filterLabel),
				Y = Pos.Bottom(filterLabel) + 1,
				Width = Dim.Fill(margin: 1),
				Height = Dim.Fill() - 2
			};

<<<<<<< HEAD
			var win = new KeyPreviewWindow("grr: Git repositories of RepoZ")
			{
				filterLabel,
				_filterField,
				_repositoryList
			};
=======
            var win = new KeyPreviewWindow("grr: Git repositories of RepoZ")
            {
            };
            win.Add(filterLabel);
            win.Add(_filterField);
            win.Add(_repositoryList);

>>>>>>> 4e2f094 (terminal fixed)

			var buttonX = Pos.Left(filterLabel);

<<<<<<< HEAD
			var navigationButton = new Button("Navigate")
			{
				Clicked = Navigate,
				X = buttonX,
				Y = Pos.AnchorEnd(1),
				CanFocus = false
			};

			if (!CanNavigate)
				navigationButton.Clicked = CopyNavigationCommandAndQuit;

			buttonX = buttonX + navigationButton.Text.Length + BUTTON_BORDER + BUTTON_DISTANCE;
			var copyPathButton = new Button("Copy")
			{
				Clicked = Copy,
				X = buttonX,
				Y = Pos.AnchorEnd(1),
				CanFocus = false
			};

			buttonX = buttonX + copyPathButton.Text.Length + BUTTON_BORDER + BUTTON_DISTANCE;
			var browseButton = new Button("Browse")
			{
				Clicked = Browse,
				X = buttonX,
				Y = Pos.AnchorEnd(1),
				CanFocus = false
			};

			var quitButton = new Button("Quit")
			{
				Clicked = Application.RequestStop,
				X = Pos.AnchorEnd("Quit".Length + BUTTON_BORDER + BUTTON_DISTANCE),
				Y = Pos.AnchorEnd(1),
				CanFocus = false
			};
=======
            var navigationButton = new Button("Navigate")
            {
                //Clicked = Navigate,
                X = buttonX,
                Y = Pos.AnchorEnd(1),
                CanFocus = false
            };
            navigationButton.Clicked += Navigate;

            if (!CanNavigate)
                navigationButton.Clicked += CopyNavigationCommandAndQuit;

            buttonX = buttonX + navigationButton.Text.Length + BUTTON_BORDER + BUTTON_DISTANCE;
            var copyPathButton = new Button("Copy")
            {

                X = buttonX,
                Y = Pos.AnchorEnd(1),
                CanFocus = false
            };
            copyPathButton.Clicked += Copy;

            buttonX = buttonX + copyPathButton.Text.Length + BUTTON_BORDER + BUTTON_DISTANCE;
            var browseButton = new Button("Browse")
            {
                X = buttonX,
                Y = Pos.AnchorEnd(1),
                CanFocus = false
            };
            browseButton.Clicked += Browse;

            var quitButton = new Button("Quit")
            {
                X = Pos.AnchorEnd("Quit".Length + BUTTON_BORDER + BUTTON_DISTANCE),
                Y = Pos.AnchorEnd(1),
                CanFocus = false
            };
            quitButton.Clicked += () =>
            {
                Application.RequestStop();
            };
>>>>>>> 4e2f094 (terminal fixed)

			win.Add(navigationButton, copyPathButton, browseButton, quitButton);

<<<<<<< HEAD
			win.DefineKeyAction(Key.Enter, () => win.SetFocus(_repositoryList));
			win.DefineKeyAction(Key.Esc, () =>
			{
				if (_filterField.HasFocus)
					SetFilterText("");
				else
					win.SetFocus(_filterField);
			});
=======
            win.DefineKeyAction(Key.Enter, () => _repositoryList.SetFocus());
            win.DefineKeyAction(Key.Esc, () =>
            {
                if (_filterField.HasFocus)
                    SetFilterText("");
                else
                    _filterField.SetFocus();
            });
>>>>>>> 4e2f094 (terminal fixed)

			if (args?.Length > 0)
				SetFilterText(String.Join(" ", args));

			Application.Top.Add(win);
			Application.Run();
		}

<<<<<<< HEAD
		private static void SetFilterText(string filter)
		{
			_filterField.Text = filter;
			_filterField.PositionCursor();
			FilterField_Changed(_filterField, NStack.ustring.Empty);
		}
=======
        private static void SetFilterText(string filter)
        {
            _filterField.Text = filter;
            _filterField.PositionCursor();
            FilterField_Changed(_filterField);
        }
>>>>>>> 4e2f094 (terminal fixed)

		private static void Navigate()
		{
			ExecuteOnSelectedRepository(r =>
			{
				var command = $"cd \"{r.SafePath}\"";

				// type the path into the console which is hosting grrui.exe to change to the directory
				TextCopy.ClipboardService.SetText(command);
				grr.ConsoleExtensions.WriteConsoleInput(Process.GetCurrentProcess(), command, waitMilliseconds: 1000);

				Application.RequestStop();
			});
		}

		private static void CopyNavigationCommandAndQuit()
		{
			ExecuteOnSelectedRepository(r =>
			{
				var command = $"cd \"{r.SafePath}\"";
				TextCopy.ClipboardService.SetText(command);
				TimelyMessage.ShowMessage("Copied to clipboard. Please paste and run the command manually now.", TimeSpan.FromMilliseconds(1000));
				Application.RequestStop();
			});
		}

		private static void Copy()
		{
			ExecuteOnSelectedRepository(r =>
			{
				var command = $"\"{r.SafePath}\"";
				TextCopy.ClipboardService.SetText(command);
			});
		}

		private static void Browse()
		{
			ExecuteOnSelectedRepository(r =>
			{
				Process.Start(new ProcessStartInfo(r.SafePath) { UseShellExecute = true });
			});
		}

		private static void ExecuteOnSelectedRepository(Action<Repository> action)
		{
			var repositories = _repositoriesView?.Repositories;
			if (repositories?.Length > _repositoryList.SelectedItem)
			{
				var current = repositories[_repositoryList.SelectedItem];
				action(current.Repository);
			}
		}

<<<<<<< HEAD
		private static void FilterField_Changed(object sender, NStack.ustring e)
		{
			_repositoriesView.Filter = (sender as TextField)?.Text?.ToString() ?? "";
			_repositoryList.SetSource(_repositoriesView.Repositories);
		}
=======
        private static void FilterField_Changed(object sender)
        {
            _repositoriesView.Filter = (sender as TextField)?.Text?.ToString() ?? "";
            _repositoryList.SetSource(_repositoriesView.Repositories);
        }
>>>>>>> 4e2f094 (terminal fixed)

		private static bool CanNavigate => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
	}
}