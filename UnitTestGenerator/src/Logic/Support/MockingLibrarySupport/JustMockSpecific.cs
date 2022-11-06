using System.Reflection;

using UnitTestGenerator.Logic.Entities;
using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Support.MockingLibrarySupport
{
    public sealed class JustMockSpecific
		: IMockLibrarySpecific
	{
		public MockingLibrary [] CanHandleMockingLibraries ()
		{
			return new [] { MockingLibrary.TelerikJustMock };
		}

		public bool IsMockingLibraryUsed { get; private set; }

		public string DeclareDependency (DependencyInfo dependency)
		{
			this.IsMockingLibraryUsed = true;
			return $"private {dependency.DependencyAbstractionType.GetRealGenericTypeName ()} {dependency.PrivateReadOnlyFieldName}Mock;";
		}

		public string AssignDependency (DependencyInfo dependency)
		{
			this.IsMockingLibraryUsed = true;
			return $"this.{dependency.PrivateReadOnlyFieldName}Mock = Mock.Create<{dependency.DependencyAbstractionType.GetRealGenericTypeName ()}> ();";
		}

		public string GetMockedObject (DependencyInfo dependency)
		{
			this.IsMockingLibraryUsed = true;
			return $"this.{dependency.PrivateReadOnlyFieldName}Mock";
		}

		public string GetVerifyAll (DependencyCallInfo oneDependencyCall)
		{
			return String.Empty;
		}

		public IList<string> GetMockedDependencyCall (DependencyCallInfo dependencyCallInfo, bool voidAssertionsRequired)
		{
			var statements = new List<string> ();
			var methodReturnType = ((MethodInfo) dependencyCallInfo.Method).ReturnType;
			var methodReturnTypeName = methodReturnType.GetRealGenericTypeName ();
			var itIsAnyList = new List<string> ();
			var arguments = new List<string> ();
			var dummyStatements = new List<string> ();
			var index = 1;

			dependencyCallInfo
				.Method
				.GetParameters ()
				.ToList ()
				.ForEach (p => {
					var paramTypeName = p.ParameterType.GetRealGenericTypeName ();
					var paramName = p.Name;

					itIsAnyList.Add ($"Arg.IsAny<{paramTypeName}> ()");
					arguments.Add ($"{paramTypeName} { paramName }");
					dummyStatements.Add ($"\t\t\t\t\t{paramName} = {paramName};{(index == 1 ? "\t\t// Callback statement is dummy. Please correct. E.g. a.Id = 1;" : string.Empty)}");
					index ++;
				});

			var paramsAsText = String.Join (", ", itIsAnyList);
			var argumentsAsText = String.Join (", ", arguments);
			var dummies = String.Join ("\r\n", dummyStatements);

			var voidAssertionText = voidAssertionsRequired ? @"
				.MustBeCalled ()" : string.Empty;

			statements.Add ($"Mock.Arrange (() => this.{dependencyCallInfo.Dependency.PrivateReadOnlyFieldName}Mock.{dependencyCallInfo.Method.Name} ({paramsAsText}))");

			if (methodReturnType == typeof (void))
			{
				statements.Add (@$"	.DoInstead (({ argumentsAsText }) => {{
{ dummies }
				}}){voidAssertionText};");
			}
			else
			{
				statements.Add ($"\t.Returns (default ({methodReturnTypeName}));\t\t// Please specify the correct return data here.");
			}

			return statements;
		}
	}
}