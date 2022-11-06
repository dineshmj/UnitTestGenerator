using System.Reflection;

using UnitTestGenerator.Logic.Entities;
using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Support.MockingLibrarySupport
{
    public sealed class FakeItEasySpecific
		: IMockLibrarySpecific
	{
		public MockingLibrary [] CanHandleMockingLibraries ()
		{
			return new [] { MockingLibrary.FakeItEasy };
		}

		public bool IsMockingLibraryUsed { get; private set; }

		public string DeclareDependency (DependencyInfo dependency)
		{
			this.IsMockingLibraryUsed = true;
			return $"private {dependency.DependencyAbstractionType.GetRealGenericTypeName ()} {dependency.PrivateReadOnlyFieldName}Fake;";
		}

		public string AssignDependency (DependencyInfo dependency)
		{
			this.IsMockingLibraryUsed = true;
			return $"this.{dependency.PrivateReadOnlyFieldName}Fake = A.Fake<{dependency.DependencyAbstractionType.GetRealGenericTypeName ()}> ();";
		}

		public string GetMockedObject (DependencyInfo dependency)
		{
			this.IsMockingLibraryUsed = true;
			return $"this.{dependency.PrivateReadOnlyFieldName}Fake";
		}

		public string GetVerifyAll (DependencyCallInfo oneDependencyCall)
		{
			var paramsAsText
				= String.Join
					(
						", ",
						oneDependencyCall
							.ParameterTypes
							.ToList ()
							.Select (t => $"A<{t.Name}>.Ignored")
							.ToArray ()
					);

			return $"A.CallTo (() => this.{ oneDependencyCall.Dependency.PrivateReadOnlyFieldName }Fake.{oneDependencyCall.Method.Name} ({paramsAsText})).MustHaveHappened ();";
		}

		public IList<string> GetMockedDependencyCall (DependencyCallInfo dependencyCallInfo, bool voidAssertionsRequired)
		{
			var statements = new List<string> ();
			var methodReturnType = ((MethodInfo) dependencyCallInfo.Method).ReturnType;
			var paramsIsAny = new List<string> ();
			var paramsDeclaration = new List<string> ();
			var dummyStatements = new List<string> ();

			dependencyCallInfo
				.Method
				.GetParameters ()
				.ToList ()
				.ForEach (p => {
					paramsIsAny.Add ($"A<{p.ParameterType.GetRealGenericTypeName ()}>.Ignored");
					paramsDeclaration.Add ($"{p.ParameterType.GetRealGenericTypeName ()} {p.Name}");
					dummyStatements.Add ($"{p.Name} = {p.Name}");
				});

			if (methodReturnType == typeof (void))
			{
				// .Callback ((Customer c) => {
				//		c = c; );
				statements.Add ($"A.CallTo (() => this.{dependencyCallInfo.Dependency.PrivateReadOnlyFieldName}Fake.{dependencyCallInfo.Method.Name} ({string.Join (", ", paramsIsAny)}))");
				statements.Add ($"\t.Invokes (({string.Join (", ", paramsDeclaration)}) => {{\t\t// Callback statement is dummy. Please correct. E.g. a.Id = 1;");
				statements.Add ($"\t\t{string.Join (";\r\n\t\t\t\t\t", dummyStatements)};");
				statements.Add ("\t});");
			}
			else
			{
				statements.Add ($"A.CallTo (() => this.{dependencyCallInfo.Dependency.PrivateReadOnlyFieldName}Fake.{dependencyCallInfo.Method.Name} ({string.Join (", ", paramsIsAny)}))");
				statements.Add ($"\t.Returns (default ({methodReturnType.GetRealGenericTypeName ()}));\t\t// Please specify the correct return data here.");
			}

			return statements;
		}
	}
}