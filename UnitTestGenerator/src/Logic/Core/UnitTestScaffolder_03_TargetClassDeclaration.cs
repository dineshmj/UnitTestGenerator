using System.Text;

using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void DeclareTargetClassPrivateFields (StringBuilder builder)
		{
			// Context.
			var targetTypeName = this.context.DeclaringTypeName;
			var isTargetStatic = this.context.DeclaringType.IsStatic ();

			// Options.
			var addFriendlyComments = this.utGen.AddFriendlyComments;

			if (isTargetStatic)
			{
				builder.AppendLine ("\t{");
			}
			else
			{
				var targetClassComment = "\r\n\t\t// Target concrete class.";

				builder.AppendLine (@$"	{{{(addFriendlyComments ? targetClassComment : string.Empty)}
		private {targetTypeName} {targetTypeName.ToCamelCase ()};
");
			}
		}
	}
}