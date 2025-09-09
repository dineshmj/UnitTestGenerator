using System.Text;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void AddConstructorUnitTestIfRelevant (StringBuilder builder, bool isHappy, string targetVariableName)
		{
			if (this.context.IsConstructor)
			{
				// Define the constructor UT.
				this.AddDecoratorAttributeForUnitTest (builder);
				this.DefineUnitTestMethodNameForConstructor (builder, isHappy);

				var additionalIndent = string.Empty;

				// ARRANGE section.
				this.StartArrangeSection (builder, out additionalIndent, isHappy);
				this.SetDependenciesWithMockedInstances (builder, additionalIndent);
				this.SetCaughtExceptionToNull (builder, additionalIndent);

				if (!isHappy)
				{
					this.SetTargetToNull(builder, targetVariableName, additionalIndent);
				}

				this.EndArrangeSection (builder);

				// ACT section.
				this.StartActSection (builder, "Constructor", out additionalIndent, isHappy);
				this.AddTryConstructorBlock (builder, additionalIndent);
				this.EndActSection (builder, out additionalIndent);

				// ASSERT section.
				//
				this.StartAssertSection (builder, isHappy, out additionalIndent);
				this.AssertCaughtException (builder, isHappy, additionalIndent);
				this.EndAssertSection (builder);
			}
		}
	}
}