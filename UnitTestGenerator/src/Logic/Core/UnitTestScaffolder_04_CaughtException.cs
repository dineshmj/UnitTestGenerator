using System.Text;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void AddCaughtExceptionDeclaration (StringBuilder builder)
		{
			if (this.utGen.TargetMethodCallContext.IsConstructor)
			{
				builder.AppendLine (@"		// Others.
		private Exception caughtException = null;
");
			}
		}

		private void SetCaughtExceptionToNull (StringBuilder builder, string additionalIndent)
		{
			builder.AppendLine ($"\t\t\t{additionalIndent}this.caughtException = null;");
		}
	}
}