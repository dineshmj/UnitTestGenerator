using System.Text;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void StartActSection (StringBuilder builder, string methodName, out string additionalIndent, bool isHappy)
		{
			// Libraries.
			var utProvider = this.utGen.UtLibraryProvider;

			builder.AppendLine (@"			// Act");

			var actStarting = utProvider.GetActBlockStarting (out additionalIndent, methodName, isHappy);

			if (string.IsNullOrEmpty (actStarting) == false)
			{
				// There is a block starting text (e.g.: NSpec UT library)
				builder.AppendLine (actStarting);
			}
			else
			{
				additionalIndent = string.Empty;
			}
		}

		private void EndActSection (StringBuilder builder, out string additionalIndent)
		{
			// Libraries.
			var utProvider = this.utGen.UtLibraryProvider;

			// Act block ending.
			var actEnding = utProvider.GetActBlockEnding ();

			if (string.IsNullOrEmpty (actEnding) == false)
			{
				builder.Append (actEnding);
			}

			additionalIndent = string.Empty;
		}
	}
}