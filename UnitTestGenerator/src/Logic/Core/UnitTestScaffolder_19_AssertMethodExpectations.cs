using System.Text;

using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void AssertMethodExpectations (StringBuilder builder, List<string> verifyAllStatements, string additionalIndent, bool isHappy)
		{
			// Libraries.
			var asserter = this.utGen.FluentLibraryProvider;

			// Context.
			var returnType = this.context.MethodReturnType;
			var returnTypeName = returnType.GetRealGenericTypeName ().ToAlias ();

			// Options.
			var addToDoComments = this.utGen.AddToDoDirectiveComments;

			if (returnType != typeof (void))
			{
				IList<string> shouldBeEqualStatements;

				if (isHappy)
				{
					shouldBeEqualStatements = asserter.GetShouldBe ("result", "expectedResult", returnTypeName);
				}
				else
				{
					shouldBeEqualStatements = asserter.GetShouldNotBe ("result", "expectedResult", returnTypeName);
				}

				if (addToDoComments)
				{
					builder.AppendLine ($"\t\t\t{additionalIndent}// TODO: ↓↓ Please set the correct {(isHappy ? "positive" : "negative")} assert statement below.");
				}

				foreach (var oneStatement in shouldBeEqualStatements)
				{
					builder.AppendLine ($"\t\t\t{additionalIndent}{oneStatement}");
				}
			}

			if (verifyAllStatements.Count > 0)
			{
				if (isHappy == false && addToDoComments)
				{
					builder.AppendLine ($"\t\t\t{additionalIndent}// TODO: ↓↓ In Edge Case scenarios, sometimes calls to the dependencies might not happen.");
					builder.AppendLine ($"\t\t\t{additionalIndent}// TODO: ↓↓ Please check if the below \"void\" dependency method calls do make sense for this Unit Test or not.");
				}

				foreach (var oneVerifyStatement in verifyAllStatements)
				{
					builder.AppendLine ($"\t\t\t{additionalIndent}{oneVerifyStatement}");
				}
			}
		}
	}
}