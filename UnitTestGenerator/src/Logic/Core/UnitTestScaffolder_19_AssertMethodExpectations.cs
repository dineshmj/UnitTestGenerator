using System;
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

			var atLeastOneAssertionLineAdded = false;

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
					atLeastOneAssertionLineAdded = true;
					builder.AppendLine ($"\t\t\t{additionalIndent}// TODO: ↓↓ Please set the correct {(isHappy ? "positive" : "negative")} assert statement below.");
				}

				foreach (var oneStatement in shouldBeEqualStatements)
				{
                    atLeastOneAssertionLineAdded = true;
                    builder.AppendLine ($"\t\t\t{additionalIndent}{oneStatement}");
				}
			}
			else
			{
				//
				// The method call returns void.
				// You can only assert the state of the target class itself.
				//
				var targetInstanceState = string.Empty;
                var targetClassName = this.context.DeclaringTypeName;
                if (isHappy)
                {
                    targetInstanceState = asserter.GetShouldNotBeNull ($"this.{targetClassName.ToCamelCase ()}");
                }
                else
                {
                    targetInstanceState = asserter.GetShouldBeNull ($"this.{targetClassName.ToCamelCase ()}");
                }

                builder.AppendLine ($"\t\t\t{additionalIndent}{targetInstanceState}\t\t// Dummy assertion statement for a void target method. Please specify correct expectation.");
            }

			// If void dependency calls are present, assert on them having been called.
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

			if (atLeastOneAssertionLineAdded == false)
			{
                builder.AppendLine($"\t\t\t// Add assertion statements here.");
            }
		}
	}
}