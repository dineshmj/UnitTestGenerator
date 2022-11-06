using System.Text;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private string DeclareTestDataSupportField ()
		{
			// Libraries.
			var testPrep = this.utGen.TestDataProvider;
			var builder = new StringBuilder ();

			// User options.
			var addFriendlyComments = this.utGen.AddFriendlyComments;

			// Test data preparation support.
			var testDataPrivateFieldDeclarationStatement = testPrep.GetPrivateFieldDeclaration ();

			if (string.IsNullOrEmpty (testDataPrivateFieldDeclarationStatement) == false)
			{
				if (addFriendlyComments)
				{
					builder.AppendLine ("\t\t// Test data preparation support.");
				}

				builder.AppendLine ($"\t\t{testDataPrivateFieldDeclarationStatement}\r\n");
			}

			return builder.ToString ();
		}
	}
}