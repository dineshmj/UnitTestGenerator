using System.Text;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void AddUnitTestsForMethodIfRelevant (StringBuilder builder)
		{
			if (this.utGen.TargetMethodCallContext.IsConstructor == false)
			{
				var methodParamDictionary
					= this.context
						.PublicMember
						.ReflectedMemberInfo
						.GetParameters ()
						.Select (p => new KeyValuePair<string, Type> (p.Name, p.ParameterType))
						.ToList ()
						.ToDictionary (x => x.Key, y => y.Value);

				var paths = new [] { "happy", "edge" };

				foreach (var path in paths)
				{
					var isHappy = (path == "happy");
					var additionalIndent = string.Empty;
					var verifyAllStatements = new List<string> ();

					// Unit Test starting.
					this.AddDecoratorAttributeForUnitTest (builder);
					this.DefineUnitTestMethodNameForMethods (builder, isHappy);

					// Private fields declaration.
					this.DeclareVariablesForMethodUnitTest (builder, methodParamDictionary, isHappy);

					// ARRANGE section.
					this.StartArrangeSection (builder, out additionalIndent, isHappy);
					this.CallSetUpMockMethods (builder, additionalIndent, isHappy, out verifyAllStatements);
					this.SetMethodParametersTestData (builder, methodParamDictionary, additionalIndent, isHappy);
					this.EndArrangeSection (builder);

					// ACT section.
					this.StartActSection (builder, this.context.MethodName, out additionalIndent, isHappy);
					this.AddTargetMethodCall (builder, methodParamDictionary, additionalIndent);
					this.EndActSection (builder, out additionalIndent);

					// ASSERT section.
					this.StartAssertSection (builder, out additionalIndent);
					this.AssertMethodExpectations (builder, verifyAllStatements, additionalIndent,  isHappy);
					this.EndAssertSection (builder);

					if (isHappy)
					{
						builder.Append ("\r\n");
					}
				}

				// Add mocking setup methods for both scenarios.
				this.AddSetUpMockDefinitions (builder);
			}
		}
	}
}