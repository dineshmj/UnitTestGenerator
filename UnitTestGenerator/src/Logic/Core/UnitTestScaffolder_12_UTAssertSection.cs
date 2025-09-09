using System.Text;

using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void StartAssertSection (StringBuilder builder, bool isHappy, out string additionalIndent)
		{
			// Libraries.
			var utProvider = this.utGen.UtLibraryProvider;

			builder.AppendLine (@"			// Assert");

			var assertStarting = utProvider.GetAssertBlockStarting (out additionalIndent, isHappy);

			if (string.IsNullOrEmpty (assertStarting) == false)
			{
				// There is a block starting text (e.g.: NSpec UT library)
				builder.AppendLine (assertStarting);
			}
			else
			{
				additionalIndent = string.Empty;
			}
		}

		private void EndAssertSection (StringBuilder builder)
		{
			// Libraries.
			var utProvider = this.utGen.UtLibraryProvider;

			var assertEnding = utProvider.GetAssertBlockEnding ();

			if (string.IsNullOrEmpty (assertEnding) == false)
			{
				builder.AppendLine (assertEnding);
			}

			builder.AppendLine ("\t\t}");
		}

		private void AssertCaughtException (StringBuilder builder, bool isHappy, string additionalIndent)
		{
			// Libraries.
			var asserter = this.utGen.FluentLibraryProvider;
			var targetFieldName = this.context.DeclaringTypeName.ToCamelCase ();

			var shouldBeNullStatement
				= isHappy
					? asserter.GetShouldBeNull ("this.caughtException")
					: asserter.GetShouldNotBeNull ("this.caughtException");

			var shouldNotBeNullStatement
				= isHappy
					? asserter.GetShouldNotBeNull ($"this.{targetFieldName}")
					: asserter.GetShouldBeNull ($"this.{targetFieldName}");

			builder.AppendLine ($"\t\t\t{additionalIndent}{shouldBeNullStatement}");
			builder.AppendLine ($"\t\t\t{additionalIndent}{shouldNotBeNullStatement}");
		}
	}
}