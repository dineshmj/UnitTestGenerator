using System.Text;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void AddTestCasesFlowerComment (StringBuilder builder)
		{
			builder.AppendLine (@"		// ============
		// Test Cases
		// ============
");
		}

		private void AddDecoratorAttributeForUnitTest (StringBuilder builder)
		{
			// Libraries.
			var utProvider = this.utGen.UtLibraryProvider;

			// Unit Class Method decorator.
			var testMethodDecorator = utProvider.GetTestMethodDecorator ();

			if (String.IsNullOrEmpty (testMethodDecorator) == false)
			{
				builder.AppendLine ($"\t\t{testMethodDecorator}");
			}
		}

		private void DefineUnitTestMethodNameForConstructor (StringBuilder builder)
		{
			// Unit Test for a Constructor.
			builder.AppendLine ($"\t\tpublic void Constructor{this.context.OverloadRankText}_Test ()");
			builder.AppendLine (@"		{");
		}

		private void DefineUnitTestMethodNameForMethods (StringBuilder builder, bool isHappy)
		{
			var unitTestMethodName = this.ArriveAtUnitTestMethodNameFor (isHappy);

			builder.AppendLine ($"\t\tpublic void {unitTestMethodName} ()");
			builder.AppendLine ("\t\t{");
		}
	}
}