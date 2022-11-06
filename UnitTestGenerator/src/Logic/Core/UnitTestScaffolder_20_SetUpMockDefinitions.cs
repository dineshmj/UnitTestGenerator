using System.Text;

using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void AddSetUpMockDefinitions (StringBuilder builder)
		{
			// Libraries.
			var mocker = this.utGen.MockLibraryProvider;

			// Context.
			var depCalls = this.context.DependencyCalls;
			var depCallsCount = depCalls.Count;

			// Options
			var addAssertionForVoidCalls = this.utGen.AddAssertionsForVoidDependencyCalls;

			if (depCallsCount > 0)
			{
				var paths = new [] { "happy", "edge" };

				builder.AppendLine (@"
		// =========================================
		// Setting up mocked dependency method calls
		// =========================================
");
				var outerIndex = 0;

				foreach (var path in paths)
				{
					outerIndex++;
					var innerIndex = 0;

					var isHappy = (path == "happy");

					foreach (var oneDependencyCall in depCalls)
					{
						innerIndex++;
						var dependencyFieldNameInPascalCase = oneDependencyCall.Dependency.PrivateReadOnlyFieldName.ToPascalCase ();

						builder.AppendLine ($"\t\tprivate void SetUp_{dependencyFieldNameInPascalCase}_For{(isHappy ? "HappyPath" : "EdgeCase")} ()");
						builder.AppendLine ("\t\t{");
						builder.AppendLine ($"\t\t\t// {(isHappy ? "Happy path" : "Edge case")}.");

						var mockStatements = mocker.GetMockedDependencyCall (oneDependencyCall, addAssertionForVoidCalls);

						foreach (var statement in mockStatements)
						{
							builder.AppendLine ($"\t\t\t{statement}");
						}

						builder.AppendLine ("\t\t}");

						if (! (outerIndex == paths.Length && innerIndex == depCallsCount))
						{
							builder.AppendLine ();
						}
					}
				}
			}
		}
	}
}