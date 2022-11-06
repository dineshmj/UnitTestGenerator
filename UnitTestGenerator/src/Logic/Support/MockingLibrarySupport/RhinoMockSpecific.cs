using System.Reflection;

using UnitTestGenerator.Logic.Entities;
using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Support.MockingLibrarySupport
{
    public sealed class RhinoMockSpecific
		: IMockLibrarySpecific
	{
		public MockingLibrary [] CanHandleMockingLibraries ()
		{
			return new [] { MockingLibrary.RhinoMock };
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
			return $"this.{dependency.PrivateReadOnlyFieldName}Mock = MockRepository.GenerateStub<{dependency.DependencyAbstractionType.GetRealGenericTypeName ()}> ();";
		}

		public string GetMockedObject (DependencyInfo dependency)
		{
			this.IsMockingLibraryUsed = true;
			return $"this.{dependency.PrivateReadOnlyFieldName}Mock";
		}

		public string GetVerifyAll (DependencyCallInfo oneDependencyCall)
		{
			var paramValues
				= String.Join
					(
						", ",
						oneDependencyCall
							.ParameterTypes
							.ToList ()
							.Select (t => $"Arg<{t.Name}>.Is.Anything")
							.ToArray ()
					);

			return $"this.{oneDependencyCall.Dependency.PrivateReadOnlyFieldName}Mock.AssertWasCalled (d => d.{ oneDependencyCall.Method.Name } ({paramValues}));";
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
					paramsIsAny.Add ($"Arg<{p.ParameterType.GetRealGenericTypeName ()}>.Is.Anything");
					paramsDeclaration.Add ($"{p.ParameterType.GetRealGenericTypeName ()} {p.Name}");
					dummyStatements.Add ($"\t\t{p.Name} = {p.Name};");
				});

			var dummies = string.Join ("\r\n", dummyStatements);

			if (methodReturnType == typeof (void))
			{
				statements.Add ($"this.{dependencyCallInfo.Dependency.PrivateReadOnlyFieldName}Mock");
				statements.Add ($"\t.Stub (d => d.{dependencyCallInfo.Method.Name} ({string.Join (", ", paramsIsAny)}))");
				statements.Add ($"\t.Callback (({ string.Join (", ", paramsDeclaration) }) => {{\t\t// Callback statement is dummy. Please correct. E.g. a.Id = 1;");
				statements.AddRange (dummyStatements);
				statements.Add ("\t});");
			}
			else
			{
				statements.Add ($"this.{dependencyCallInfo.Dependency.PrivateReadOnlyFieldName}Mock");
				statements.Add ($"\t.Stub (d => d.{dependencyCallInfo.Method.Name} ({string.Join (", ", paramsIsAny)}))");
				statements.Add ($"\t.Return (default ({methodReturnType.GetRealGenericTypeName ()}));\t\t// Please specify the correct return data here.");
			}

			return statements;
		}
	}
}