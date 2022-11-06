using System.Text;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void StartArrangeSection (StringBuilder builder, out string additionalIndent, bool isHappy)
		{
			// Libraries.
			var utProvider = this.utGen.UtLibraryProvider;

			builder.AppendLine (@"			// Arrange");

			var arrangeStarting = utProvider.GetArrangeBlockStarting (out additionalIndent, this.context.MethodName, isHappy);

			if (string.IsNullOrEmpty (arrangeStarting) == false)
			{
				// There is a block starting text (e.g.: NSpec UT library)
				builder.AppendLine (arrangeStarting);
			}
			else
			{
				additionalIndent = string.Empty;
			}
		}

		private void EndArrangeSection (StringBuilder builder)
		{
			// Libraries.
			var utProvider = this.utGen.UtLibraryProvider;

			// End of Arrange block.
			var arrangeEnding = utProvider.GetArrangeBlockEnding ();

			if (string.IsNullOrEmpty (arrangeEnding) == false)
			{
				builder.AppendLine (arrangeEnding);
			}

			builder.AppendLine ();
		}

		private void SetDependenciesWithMockedInstances (StringBuilder builder, string additionalIndent)
		{
			// Libraries.
			var mocker = this.utGen.MockLibraryProvider;

			// Context.
			var paramTypes = this.context.ParameterTypes;
			var paramCount = paramTypes.Count;

			if (paramCount > 0)
			{
				foreach (var oneParamType in paramTypes)
				{
					var dependency = this.context.FindDependency (oneParamType);

					if (null != dependency)
					{
						// Assign each dependency with mocked instances.
						builder.AppendLine ($"\t\t\t{additionalIndent}{mocker.AssignDependency (dependency)}");
					}
				}
			}
		}
	}
}