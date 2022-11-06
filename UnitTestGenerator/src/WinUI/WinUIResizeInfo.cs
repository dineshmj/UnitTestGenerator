using System.Windows;

namespace UnitTestGenerator
{
	public sealed class WinUIResizeInfo
	{
		private static WinUIResizeInfo? definedInstance;
		private static readonly object syncLocker = new ();

		public static WinUIResizeInfo DefinedInstance
		{
			get
			{
				lock (syncLocker)
				{
					if (WinUIResizeInfo.definedInstance == null)
					{
						WinUIResizeInfo.definedInstance = new ();
					}

					return WinUIResizeInfo.definedInstance;
				}
			}
		}

		// General
		public float SectionLabelFontSize { get; }

		// Tab 1
		public Point DLLPathLabelLocation { get; }
		public Point ConcreteClassLabelLocation { get; }
		public Point QuickSearchLabelLocation { get; }

		public Point DLLPathTextBoxLocation { get; }
		public Point BrowseDllButtonLocation { get; }
		public Point ConcreteClassDropDownLocation { get; }
		public Point QuickSearchTextBoxLocation { get; }

		public Size DLLPathTextBoxSize { get; }
		public Size ConcreteClassDropDownSize { get; }
		public Size QuickSearchTextBoxSize { get; }
		public Size BrowseDllButtonSize { get; }
		public Size PublicMethodsPresentCheckedListBoxSize { get; }

		// Tab 2
		public Size SelectedMethodsListBoxSize { get; }

		// Others
		public int HeighlighterLabelDepthDifference { get; }

		private WinUIResizeInfo ()
		{
			var zoomLevel = (int) (100 * Screen.PrimaryScreen.Bounds.Width / SystemParameters.PrimaryScreenWidth);

			switch (zoomLevel)
			{
				case 150:
					// General
					this.SectionLabelFontSize = 12;

					// Tab 1 - Labels:
					this.DLLPathLabelLocation = new Point (381, 20);
					this.ConcreteClassLabelLocation = new Point (324, 51);
					this.QuickSearchLabelLocation = new Point (340, 84);

					// Tab 1 - Fields:
					this.DLLPathTextBoxLocation = new Point (500, 15);
					this.BrowseDllButtonLocation = new Point (1755, 15);
					this.ConcreteClassDropDownLocation = new Point (500, 48);
					this.QuickSearchTextBoxLocation = new Point (500, 81);

					this.DLLPathTextBoxSize = new Size (1249, 36);
					this.BrowseDllButtonSize = new Size (49, 33);
					this.ConcreteClassDropDownSize = new Size (1304, 36);
					this.QuickSearchTextBoxSize = new Size (1304, 36);

					this.PublicMethodsPresentCheckedListBoxSize = new Size (1789, 781);

					// Tab 2 - Fields:
					this.SelectedMethodsListBoxSize = new Size (1781, 132);

					// Others.
					this.HeighlighterLabelDepthDifference = 5;
					break;

				default:
					// General
					this.SectionLabelFontSize = 18;

					// Tab 1 - Labels:
					this.DLLPathLabelLocation = new Point (366, 20);
					this.ConcreteClassLabelLocation = new Point (328, 51);
					this.QuickSearchLabelLocation = new Point (340, 84);

					// Tab 1 - Fields:
					this.DLLPathTextBoxLocation = new Point (442, 15);
					this.BrowseDllButtonLocation = new Point (1772, 15);
					this.ConcreteClassDropDownLocation = new Point (442, 48);
					this.QuickSearchTextBoxLocation = new Point (442, 81);

					this.DLLPathTextBoxSize = new Size (1324, 26);
					this.BrowseDllButtonSize = new Size (32, 26);
					this.ConcreteClassDropDownSize = new Size (1362, 27);
					this.QuickSearchTextBoxSize = new Size (1362, 26);

					this.PublicMethodsPresentCheckedListBoxSize = new Size (1789, 781);

					// Tab 2 - Fields:
					this.SelectedMethodsListBoxSize = new Size (1781, 130);

					// Others.
					this.HeighlighterLabelDepthDifference = 10;
					break;
			}
		}
	}
}