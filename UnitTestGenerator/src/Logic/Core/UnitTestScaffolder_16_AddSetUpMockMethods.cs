using System.Reflection;
using System.Text;

using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void CallSetUpMockMethods (StringBuilder builder, string additionalIndent, bool isHappy, out List<string> verifyAllStatements)
		{
			// Libraries.
			var mocker = this.utGen.MockLibraryProvider;

			// Context.
			var depCalls = this.context.DependencyCalls;
			var depCallsCount = depCalls.Count;
			verifyAllStatements = new List<string> ();

			// Options.
			var addFriendlyComments = this.utGen.AddFriendlyComments;
			var assertForVoidCalls = this.utGen.AddAssertionsForVoidDependencyCalls;

			if (depCallsCount > 0)
			{
				if (addFriendlyComments)
				{
					builder.AppendLine ($"\t\t\t{additionalIndent}// Mock dependency method calls");
				}

				foreach (var oneDependencyCall in depCalls)
				{
					var setUpMethodName = $"SetUp_{oneDependencyCall.Dependency.PrivateReadOnlyFieldName.ToPascalCase ()}_For{(isHappy ? "HappyPath" : "EdgeCase")}";

					builder.AppendLine ($"\t\t\t{additionalIndent}this.{setUpMethodName} ();");

					if (assertForVoidCalls && ((MethodInfo) oneDependencyCall.Method).ReturnType == typeof (void))
					{
						var verifyAllStatement = mocker.GetVerifyAll (oneDependencyCall);

						if (string.IsNullOrEmpty (verifyAllStatement) == false)
						{
							verifyAllStatements.Add (verifyAllStatement);
						}
					}
				}

				builder.Append ("\r\n");
			}
		}
	}
}