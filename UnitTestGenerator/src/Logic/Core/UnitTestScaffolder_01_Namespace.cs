using System.Text;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void AddNamespace (StringBuilder builder)
		{
			var targetType = this.context.DeclaringType;

			builder.AppendLine ($"namespace {targetType.Namespace}.Test");
			builder.AppendLine ("{");
		}
	}
}