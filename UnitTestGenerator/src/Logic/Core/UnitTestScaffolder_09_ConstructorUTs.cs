using System.Text;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void AddConstructorUnitTestIfRelevant (StringBuilder builder)
		{
			if (this.context.IsConstructor)
			{
				// Define the constructor UT.
				this.AddDecoratorAttributeForUnitTest (builder);
				this.DefineUnitTestMethodNameForConstructor (builder);

				var additionalIndent = string.Empty;

				// ARRANGE section.
				this.StartArrangeSection (builder, out additionalIndent, true);
				this.SetDependenciesWithMockedInstances (builder, additionalIndent);
				this.SetCaughtExceptionToNull (builder, additionalIndent);
				this.EndArrangeSection (builder);

				// ACT section.
				this.StartActSection (builder, "Constructor", out additionalIndent, true);
				this.AddTryConstructorBlock (builder, additionalIndent);
				this.EndActSection (builder, out additionalIndent);

				// ASSERT section.
				//
				this.StartAssertSection (builder, out additionalIndent);
				this.AssertCaughtException (builder, additionalIndent);
				this.EndAssertSection (builder);
			}
		}
	}
}