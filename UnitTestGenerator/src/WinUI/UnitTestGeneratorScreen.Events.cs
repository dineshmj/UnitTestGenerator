using System.Reflection;

using UnitTestGenerator.Logic.Core;
using UnitTestGenerator.Logic.Entities;
using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator
{
	public partial class UnitTestGeneratorScreen
	{
		private bool doNotTriggerQuickSearch = true;

		private void browseDllButton_Click (object sender, EventArgs e)
		{
			if (Directory.Exists (this.options.LastBrowsedDllPath))
			{
				this.openDllDialog.InitialDirectory
					= Path.GetDirectoryName (this.options.LastBrowsedDllPath);
			}

			if (this.openDllDialog.ShowDialog (this) == DialogResult.OK)
			{
				this.options.SetLastBrowsedDllTo (this.openDllDialog.FileName);
				this.dllPathTextBox.Text = this.openDllDialog.FileName;
			}
		}

		private void dllPathTextBox_TextChanged (object sender, EventArgs e)
		{
			if (File.Exists (this.dllPathTextBox.Text) == false)
			{
				return;
			}

			try
			{
				// Load the DLL assembly.
				var targetAssembly = Assembly.LoadFrom (this.dllPathTextBox.Text);

				// Get the concrete types from the DLL.
				var concreteTypes
					= targetAssembly.GetExportedTypes ()
						 // .Where (type => type.IsClass && type.IsAbstract == false)
						 .Where (type => type.IsClass)
						 .ToList ();

				// Look for each conrete type.
				this.concreteClassesDropDownList.DataSource = concreteTypes;
				this.concreteClassesDropDownList.DisplayMember = nameof (Type.FullName);
			}
			catch (Exception ex)
			{
				MessageBox.Show
					(
						@$"An error occurred while attempting to load the Concrete types from the specified DLL assembly.

Error description:

====================================
{ex.Message}
====================================

Please ensure that the DLL location has all other DLLs referred by the selected DLL assembly.",
						"An error occurred while loading DLL",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
					);

				this.dllPathTextBox.Text = string.Empty;
			}
		}

		private void quickSearchTextBox_TextChanged (object sender, EventArgs e)
		{
			if (this.doNotTriggerQuickSearch)
			{
				return;
			}

			if (string.IsNullOrWhiteSpace (this.quickSearchTextBox.Text) == false)
			{
				this.options.SetSearchPatternTo (this.quickSearchTextBox.Text.Trim ());
			}

			var concreteTypes = (IList<Type>) this.concreteClassesDropDownList.DataSource;

			if (concreteTypes != null && concreteTypes.Count > 0)
			{
				var firstMatchingConcreteType
					= concreteTypes.FirstOrDefault
						(
							t =>
								t.Name.IndexOf (this.quickSearchTextBox.Text, StringComparison.InvariantCultureIgnoreCase) != -1
						);

				if (firstMatchingConcreteType == null)
				{
					this.concreteClassesDropDownList.SelectedIndex = -1;
					return;
				}

				this.concreteClassesDropDownList.SelectedItem = firstMatchingConcreteType;
			}
		}

		private void concreteClassesDropDownList_SelectedIndexChanged (object sender, EventArgs e)
		{
			if (this.concreteClassesDropDownList.SelectedItem != null)
			{
				var targetType = (Type) this.concreteClassesDropDownList.SelectedItem;

				this.doNotTriggerQuickSearch = true;
				this.quickSearchTextBox.Text = targetType.Name;
				this.doNotTriggerQuickSearch = false;

				if (string.IsNullOrWhiteSpace (this.quickSearchTextBox.Text) == false)
				{
					this.options.SetSearchPatternTo (this.quickSearchTextBox.Text.Trim ());
				}

				var publicMembers = new List<PublicMember> ();
				var reflector = new IntermediateLanguageReader ();

				var overloadRank = 1;

				publicMembers.AddRange
					(
						targetType
							.GetConstructors
								(
									BindingFlags.DeclaredOnly
									| BindingFlags.Instance
									| BindingFlags.Public
								)
							.Select (c => {
								var dependencyCalls = reflector.GetDependencyMethodCalls (c);

								var publicMember = new PublicMember (MemberType.Constructor, c, overloadRank, dependencyCalls);
								overloadRank++;
								return publicMember;
							})
							.ToList ()
					);

				var overloadDictionary = new Dictionary<string, int> ();

				publicMembers.AddRange
					(
						targetType.GetMethods
							(
								BindingFlags.DeclaredOnly   // Only public members of the Target Class; do not include those of parent class.
								| BindingFlags.Instance
								| BindingFlags.Public
								| BindingFlags.Static
							)
							.Where (method => !method.IsSpecialName)  // Omit get_ property methods.
							.Select (method => {
								var dependencyCalls = reflector.GetDependencyMethodCalls (method);

								overloadRank = 1;
								if (overloadDictionary.ContainsKey (method.Name))
								{
									overloadRank = overloadDictionary [method.Name] + 1;
									overloadDictionary [method.Name] = overloadRank;
								}
								else
								{
									overloadDictionary [method.Name] = 1;
								}
								return new PublicMember (MemberType.Method, method, overloadRank, dependencyCalls);
							})
							.ToList ()
					);

				var listBox = (ListBox) this.publicMethodsPresentCheckedListBox;

				listBox.DataSource = publicMembers;
				listBox.DisplayMember = nameof (PublicMember.Representation);

				for (var i = 0; i < this.publicMethodsPresentCheckedListBox.Items.Count; i++)
				{
					this.publicMethodsPresentCheckedListBox.SetItemChecked (i, true);
				}
			}
		}

		private void utMethodNameStartsWithShouldRadioButton_CheckedChanged (object sender, EventArgs e)
		{
			this.options.SetUnitTestMethodNamingStyleTo (UnitTestMethodNamingStyle.MethodNameStartsWithShould);

			this.utMethodNamingStyleHighlighterLabel.Top = this.utMethodNameStartsWithShouldRadioButton.Top - this.uiInfo.HeighlighterLabelDepthDifference;
			this.utMethodNameStartsWithShouldRadioButton.BackColor = this.utMethodNamingStyleHighlighterLabel.BackColor;

			this.utMethodNameStartsWithWhenRadioButton.BackColor = this.radioOptionBackColor;
		}

		private void utMethodNameStartsWithWhenRadioButton_CheckedChanged (object sender, EventArgs e)
		{
			this.options.SetUnitTestMethodNamingStyleTo (UnitTestMethodNamingStyle.MethodNameStartsWithWhen);

			this.utMethodNamingStyleHighlighterLabel.Top = this.utMethodNameStartsWithWhenRadioButton.Top - this.uiInfo.HeighlighterLabelDepthDifference;
			this.utMethodNameStartsWithWhenRadioButton.BackColor = this.utMethodNamingStyleHighlighterLabel.BackColor;

			this.utMethodNameStartsWithShouldRadioButton.BackColor = this.radioOptionBackColor;
		}

		private void utFrameworkChanged (object sender, EventArgs e)
		{
			var selectedRadio = (RadioButton) sender;
			var correspUtLibrary = this.utRadiosDictionary [selectedRadio];

			this.options.SetUnitTestLibraryTo (correspUtLibrary);
			this.UserOptionChanged ();
			this.HighlightUTRadio (selectedRadio, correspUtLibrary);
		}

		private void mockFrameworkChanged (object sender, EventArgs e)
		{
			var selectedRadio = (RadioButton) sender;
			var correspMockLibrary = this.mockRadiosDictionary [selectedRadio];

			this.options.SetMockingLibraryTo (correspMockLibrary);
			this.UserOptionChanged ();
			this.HighlightMockRadio (selectedRadio, correspMockLibrary);
		}

		private void fluentFrameworkChanged (object sender, EventArgs e)
		{
			var selectedRadio = (RadioButton) sender;
			var correspFluentLibrary = this.fluentRadiosDictionary [selectedRadio];

			this.options.SetFluentAssertionLibraryTo (correspFluentLibrary);
			this.UserOptionChanged ();
			this.HighlightFluentRadio (selectedRadio, correspFluentLibrary);
		}

		private void testDataFrameworkChanged (object sender, EventArgs e)
		{
			var selectedRadio = (RadioButton) sender;
			var correspTestDataLibrary = this.testDataRadiosDictionary [selectedRadio];

			this.options.SetTestDataPreparationLibraryTo (correspTestDataLibrary);
			this.UserOptionChanged ();
			this.HighlightTestDataRadio (selectedRadio, correspTestDataLibrary);
		}

		private void publicMethodsPresentCheckedListBox_ItemCheck (object sender, ItemCheckEventArgs e)
		{
			this.generateUnitTestsButton.Enabled = this.publicMethodsPresentCheckedListBox.CheckedItems.Count > 0;
		}

		private void selectAllButton_Click (object sender, EventArgs e)
		{
			for (var i = 0; i < this.publicMethodsPresentCheckedListBox.Items.Count; i++)
			{
				this.publicMethodsPresentCheckedListBox.SetItemChecked (i, true);
			}

			this.UserOptionChanged ();
			this.generateUnitTestsButton.Enabled = this.publicMethodsPresentCheckedListBox.CheckedItems.Count > 0;
		}

		private void deselectAllButton_Click (object sender, EventArgs e)
		{
			for (var i = 0; i < this.publicMethodsPresentCheckedListBox.Items.Count; i++)
			{
				this.publicMethodsPresentCheckedListBox.SetItemChecked (i, false);
			}

			this.UserOptionChanged ();
			this.generateUnitTestsButton.Enabled = publicMethodsPresentCheckedListBox.CheckedItems.Count > 0;
		}

		private void generatedUnitTestRichTextBox_KeyDown (object sender, KeyEventArgs e)
		{
			e.SuppressKeyPress = true;
		}

		private void saveUnitTestsButton_Click (object sender, EventArgs e)
		{
			if (selectedMethodsListBox.Items.Count == 0)
			{
				MessageBox.Show ("You have not generated any Unit Tests yet.\r\n\r\nPlease generate Unit Tests first.", "Unit Tests not yet generated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.unitGenTabControl.SelectedTab = this.targetPublicMethodsTabPage;
				return;
			}
			else if (selectedMethodsListBox.SelectedIndex == -1)
			{
				MessageBox.Show ("Please select a Constructor / method, whose Unit Test is to be saved.", "Select Constructor / Method", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (Directory.Exists (this.options.LastUnitTestSaveLocation))
			{
				this.whereToSaveFolderDialog.InitialDirectory = this.options.LastUnitTestSaveLocation;
				this.whereToSaveFolderDialog.SelectedPath = this.options.LastUnitTestSaveLocation;
			}

			if (this.whereToSaveFolderDialog.ShowDialog () == DialogResult.OK)
			{
				this.options.SetLastUnitTestSaveLocationTo (this.whereToSaveFolderDialog.SelectedPath);

				// Identify the Public Member.
				var publicMember = (PublicMember) selectedMethodsListBox.SelectedItem;

				if (this.generatedUnitTests.ContainsKey (publicMember))
				{
					// Get generated Unit Test code.
					var generatedUnitTest = this.generatedUnitTests? [publicMember];
					var targetClassName
						= publicMember
							.ReflectedMemberInfo
							.DeclaringType
							.GetRealGenericTypeName ()
							.Replace ("<", "_")
							.Replace (">", "_");
					
					var methodName = publicMember.ReflectedMemberInfo.Name;
					var unitTestFileName = $"{targetClassName}_{ methodName}_{ (publicMember.OverloadRank > 1 ? publicMember.OverloadRank.ToString () + "_" : string.Empty ) }Test.cs";
					var fullPath = $"{this.whereToSaveFolderDialog.SelectedPath}\\{unitTestFileName}";
					var renamedFilePath = string.Empty;
					var additionalMessage = string.Empty;

					if (File.Exists (fullPath))
					{
						if (MessageBox.Show ("A Unit Test file for the selected class and method already exists.\r\n\r\nDo you want to rename the existing file, so that you can save this version?", "Unit Test file already exists", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
						{
							return;
						}

						renamedFilePath = fullPath.Replace ("_Test.cs", $"_Test.Old_{DateTime.Now.ToString ("yyyy_MM_dd_hh_mm_ss")}.cs");
						File.Move (fullPath, renamedFilePath);

						additionalMessage
							= $"\r\n\r\nThe original Unit Test file was renamed to {renamedFilePath.Replace (this.whereToSaveFolderDialog.SelectedPath + "\\", string.Empty)}";
					}

					File.WriteAllText (fullPath, generatedUnitTest);
					MessageBox.Show ($"The Unit Test file has been saved.{ additionalMessage }", "Unit Test saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void copyUnitTestCodeButton_Click (object sender, EventArgs e)
		{
			if (selectedMethodsListBox.Items.Count == 0)
			{
				MessageBox.Show ("You have not generated any Unit Tests yet.\r\n\r\nPlease generate Unit Tests first.", "Unit Tests not yet generated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.unitGenTabControl.SelectedTab = this.targetPublicMethodsTabPage;
				return;
			}
			else if (selectedMethodsListBox.SelectedIndex == -1)
			{
				MessageBox.Show ("Please select a Constructor / method, whose Unit Test is to be saved.", "Select Constructor / Method", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			Clipboard.SetText (this.generatedUnitTestRichTextBox.Text, TextDataFormat.UnicodeText);
			MessageBox.Show ("Unit Test code copied to clipboard.", "Copying successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void addAssertionForVoidDependencyCallsCheckBox_CheckedChanged (object sender, EventArgs e)
		{
			this.options.SetAddAssertionsForVoidDependencyCallsTo (this.addAssertionForVoidDependencyCallsCheckBox.Checked);
			this.UserOptionChanged ();
		}

		private void addNamespacesCheckBox_CheckedChanged (object sender, EventArgs e)
		{
			this.options.SetAddUsingStatementsTo (this.addUsingNamespacesCheckBox.Checked);
			this.UserOptionChanged ();
		}

		private void addToDoStatementsCheckBox_CheckedChanged (object sender, EventArgs e)
		{
			this.options.SetAddToDoStatementsTo (this.addToDoStatementsCheckBox.Checked);
			this.UserOptionChanged ();
		}

		private void addFriendlyCommentsCheckBox_CheckedChanged (object sender, EventArgs e)
		{
			this.options.SetAddFriendlyCommentsTo (this.addFriendlyCommentsCheckBox.Checked);
			this.UserOptionChanged ();
		}

		private void savePreferencesCheckBox_CheckedChanged (object sender, EventArgs e)
		{
			this.options.SetRememberPreferencesTo (rememberMyPreferencesCheckBox.Checked);
		}

		private void resetToDefaultOptionsButton_Click (object sender, EventArgs e)
		{
			if (
				MessageBox.Show
					(
						"Are you sure to reset Unit Test Generation options to their default values?",
						"Please confirm resetting options",
						MessageBoxButtons.OKCancel,
						MessageBoxIcon.Question,
						MessageBoxDefaultButton.Button2
					) == DialogResult.OK
				)
			{
				this.options.Reset ();
				this.HighlightUIControlsBasedOnUserPreferences ();
			}
		}
	}
}