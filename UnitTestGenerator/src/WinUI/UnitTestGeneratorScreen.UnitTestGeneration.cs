using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator
{
    public partial class UnitTestGeneratorScreen
    {
		private IDictionary<PublicMember, string> generatedUnitTests = new Dictionary<PublicMember, string> ();

		private void generateUnitTestsButton_Click (object sender, EventArgs e)
		{
			var selectedPublicMembers = new List<PublicMember> ();

			foreach (var oneItem in this.publicMethodsPresentCheckedListBox.CheckedItems)
			{
				selectedPublicMembers.Add ((PublicMember) oneItem);
			}

			this.selectedMethodsListBox.DataSource = selectedPublicMembers;
			this.selectedMethodsListBox.DisplayMember = nameof (PublicMember.Representation);

			var scaffoldOption
				= new UnitTestScaffoldOption
					(
						this.options.UnitTestLibrary,
						this.options.MockingLibrary,
						this.options.FluentAssertionLibrary,
						this.options.TestDataPreparationLibrary,
						this.options.UnitTestMethodNamingStyle,
						this.options.AddAssertionsForVoidDependencyCalls,
						this.options.AddUsingStatementsForUnusedLibrariesAlso,
						this.options.AddToDoComments,
						this.options.AddFriendlyComments
					);

			// Generate Unit Tests for the selected members.
			this.generatedUnitTests = this.utScaffolder.GenerateUnitTestsFor (selectedPublicMembers, scaffoldOption);

			// Show the names of the methods for which Unit Tests are generated.
			this.selectedMethodsListBox.SelectedIndex = -1;
			unitGenTabControl.SelectedTab = this.generatedUnitTestsTabPage;
		}
	}
}