using System.Text;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void AddUTClassDecoratorAttribute (StringBuilder builder)
		{
			var utClassDecorator = this.utGen.UtLibraryProvider.GetTestClassDecorator ();

			if (String.IsNullOrEmpty (utClassDecorator) == false)
			{
				builder.AppendLine ($"\t{utClassDecorator}");
			}
		}

		private void AddUTClassName (StringBuilder builder)
		{
			builder.AppendLine ($"\tpublic sealed class {this.GetUnitTestClassName ()}");
		}

		private void AddUTClassInheritingParentName (StringBuilder builder)
		{
			var inherits = this.utGen.UtLibraryProvider.UnitTestClassInherits ();

			if (String.IsNullOrEmpty (inherits) == false)
			{
				builder.AppendLine ($"\t\t: {inherits}");
			}
		}

		private string GetUnitTestClassName ()
		{
			// Context.
			var targetTypeName = this.context.DeclaringTypeName;
			var isConstructor = this.context.IsConstructor;
			var methodName = this.context.MethodName;
			var overloadRankText = this.context.OverloadRankText;

			return $"{targetTypeName}_{(isConstructor ? "Ctor" : methodName)}{overloadRankText}_Test";
		}
	}
}