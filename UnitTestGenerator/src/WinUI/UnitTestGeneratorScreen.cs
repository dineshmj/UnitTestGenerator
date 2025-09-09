using System.Reflection;
using UnitTestGenerator.Logic.Core;
using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator
{
	public partial class UnitTestGeneratorScreen
		: Form
	{
		private readonly UnitTestGenerationOptions options = UnitTestGenerationOptions.DefinedInstance;
		private WinUIResizeInfo uiInfo = WinUIResizeInfo.DefinedInstance;

		private readonly IUnitTestScaffolder utScaffolder;

		public UnitTestGeneratorScreen ()
		{
			this.InitializeComponent ();

			this.utScaffolder = new UnitTestScaffolder ();

			// Set up UI fields' details.
			this.PrepareRadiosCollection ();
			this.PrepareRadiosAndEnumsDictionary ();
		}

		private void UnitTestGeneratorScreen_Load (object sender, EventArgs e)
		{
			// Set up various .NET Framework runtimes for proper target DLL loading.
			this.SetupVariousDotNetRuntimesForProperTargetDllLoading ();

			this.doNotTriggerQuickSearch = true;
			this.SetUIControlsBasedOnScreenZoomLevel ();
			this.HighlightUIControlsBasedOnUserPreferences ();

			// Last browsed DLL file path.
			if (File.Exists (this.options.LastBrowsedDllPath))
			{
				this.dllPathTextBox.Text = this.options.LastBrowsedDllPath;
			}

			this.quickSearchTextBox.Text = this.options.SearchText;
			this.doNotTriggerQuickSearch = false;
			this.options.SetReady ();
		}

		private void SetupVariousDotNetRuntimesForProperTargetDllLoading ()
		{
			var aspDotNetRuntimeAssemblyFolderLocations
				= new [] {
					"C:\\Program Files\\dotnet\\shared\\Microsoft.AspNetCore.App",
					"C:\\Program Files (x86)\\dotnet\\shared\\Microsoft.AspNetCore.App"
				};

			var aspDotNetFrameworkVersionDirectoryPaths = new List<string> ();

			foreach (var oneLocation in aspDotNetRuntimeAssemblyFolderLocations)
			{
				if (Directory.Exists (oneLocation))
				{
					var fxVersionSubDirectories = Directory.GetDirectories (oneLocation);

					foreach (var oneFxVersionFolder in fxVersionSubDirectories)
					{
						if (Directory.Exists (oneFxVersionFolder))
						{
							aspDotNetFrameworkVersionDirectoryPaths.Add (oneFxVersionFolder);
						}
					}

					// If the 64-bit parent directory is found, then no need to look for the 32-bit parent directory.
					break;
				}
			}

			AppDomain.CurrentDomain.AssemblyResolve += (s, a) =>
			{
				foreach (var onePath in aspDotNetFrameworkVersionDirectoryPaths)
				{
					var assemblyName = new AssemblyName (a.Name).Name + ".dll";
					var assemblyPath = Path.Combine (onePath, assemblyName);

					if (File.Exists (assemblyPath))
					{
						return Assembly.LoadFrom (assemblyPath);
					}
				}

				return null;
			};
		}

		private void SetUIControlsBasedOnScreenZoomLevel ()
		{
			// Tab 1 - Labels.
			this.dllPathLabel.Location = this.uiInfo.DLLPathLabelLocation;
			this.concreteClassLabel.Location = this.uiInfo.ConcreteClassLabelLocation;
			this.quickSearchLabel.Location = this.uiInfo.QuickSearchLabelLocation;

			// Tab 1 - Fields and buttons.
			this.dllPathTextBox.Location = this.uiInfo.DLLPathTextBoxLocation;
			this.browseDllButton.Location = this.uiInfo.BrowseDllButtonLocation;
			this.concreteClassesDropDownList.Location = this.uiInfo.ConcreteClassDropDownLocation;
			this.quickSearchTextBox.Location = this.uiInfo.QuickSearchTextBoxLocation;

			this.dllPathTextBox.Size = this.uiInfo.DLLPathTextBoxSize;
			this.browseDllButton.Size = this.uiInfo.BrowseDllButtonSize;
			this.concreteClassesDropDownList.Size = this.uiInfo.ConcreteClassDropDownSize;
			this.quickSearchTextBox.Size = this.uiInfo.QuickSearchTextBoxSize;

			this.publicMethodsPresentCheckedListBox.Size = this.uiInfo.PublicMethodsPresentCheckedListBoxSize;

			// Tab 2 - Fields.
			this.selectedMethodsListBox.Size = this.uiInfo.SelectedMethodsListBoxSize;

			// Section labels.
			var sectionLabelFont = new Font (this.selectTargetClassSectionLabel.Font.Name, this.uiInfo.SectionLabelFontSize);

			this.selectTargetClassSectionLabel.Font = sectionLabelFont;
			this.unitTestFrameworkSectionLabel.Font = sectionLabelFont;
			this.mockingLibrarySectionLabel.Font = sectionLabelFont;
			this.fluentAssertionLibrarySectionLabel.Font = sectionLabelFont;
			this.testDataPrepLibrarySectionLabel.Font = sectionLabelFont;
			this.unitTestMethodNamingStyleSectionLabel.Font = sectionLabelFont;
		}

		private void HighlightUIControlsBasedOnUserPreferences ()
		{
			this.rememberMyPreferencesCheckBox.Checked = this.options.RememberMyPreferences;

			this.CheckAppropriateLibraryRadios ();

			// UT method naming style
			this.utMethodNameStartsWithShouldRadioButton.Checked = (this.options.UnitTestMethodNamingStyle == UnitTestMethodNamingStyle.MethodNameStartsWithShould);
			this.utMethodNameStartsWithWhenRadioButton.Checked = (this.options.UnitTestMethodNamingStyle == UnitTestMethodNamingStyle.MethodNameStartsWithWhen);
			
			this.addAssertionForVoidDependencyCallsCheckBox.Checked = this.options.AddAssertionsForVoidDependencyCalls;
			this.addUsingNamespacesCheckBox.Checked = this.options.AddUsingStatementsForUnusedLibrariesAlso;
			this.addToDoStatementsCheckBox.Checked = this.options.AddToDoComments;
			this.addFriendlyCommentsCheckBox.Checked = this.options.AddFriendlyComments;
		}

		private void UserOptionChanged ()
		{
			var dataSource = (List<PublicMember>) this.selectedMethodsListBox.DataSource;
			dataSource?.Clear ();
			this.generatedUnitTestRichTextBox.Text = string.Empty;
		}
	}
}