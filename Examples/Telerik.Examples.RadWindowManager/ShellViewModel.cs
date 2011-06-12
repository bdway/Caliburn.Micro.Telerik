using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Telerik.Examples.RadWindowManager
{
	[Export(typeof (IShell))]
	public class ShellViewModel : IShell
	{
		private readonly IWindowManager windowManager;

		[ImportingConstructor]
		public ShellViewModel(IWindowManager windowManager)
		{
			this.windowManager = windowManager;
		}

		public void ShowDialog()
		{
			var dialog = new DialogViewModel();
			windowManager.ShowDialog(dialog);
		}

		public void ShowNotification()
		{
			windowManager.ShowNotification(new NotificationViewModel {Message = "Hi there!"}, 2000);
		}

		public void ShowAlert()
		{
			windowManager.Alert("This is the title", "And here comes the content...");
		}

		public void ShowConfirmation()
		{
			windowManager.Confirm(
				"This is the title", 
				"What should be confirmed, text...", 
				b => windowManager.Alert("result", "is: " + b));
		}

		public void ShowPrompt()
		{
			windowManager.Prompt("Give me", "A value (default is 'something'):", "something", (b, s) =>
			{
				if (b)
					windowManager.Alert("Prompt value", "Is: " + s);
			});
		}
	}
}