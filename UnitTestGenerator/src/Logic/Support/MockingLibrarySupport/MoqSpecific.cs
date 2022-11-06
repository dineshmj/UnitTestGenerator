using System.Reflection;

using UnitTestGenerator.Logic.Entities;
using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Support.MockingLibrarySupport
{
    public sealed class MoqSpecific
		: IMockLibrarySpecific
	{
		public MockingLibrary [] CanHandleMockingLibraries ()
		{
			return new [] { MockingLibrary.Moq };
		}

		public bool IsMockingLibraryUsed { get; private set; }

		public string DeclareDependency (DependencyInfo dependency)
		{
			this.IsMockingLibraryUsed = true;
			return $"private Mock<{dependency.DependencyAbstractionType.GetRealGenericTypeName ()}> {dependency.PrivateReadOnlyFieldName}Mock;";
		}

		public string AssignDependency (DependencyInfo dependency)
		{
			this.IsMockingLibraryUsed = true;
			return $"this.{dependency.PrivateReadOnlyFieldName}Mock = new Mock<{dependency.DependencyAbstractionType.GetRealGenericTypeName ()}> ();";
		}

		public string GetMockedObject (DependencyInfo dependency)
		{
			this.IsMockingLibraryUsed = true;
			return $"this.{dependency.PrivateReadOnlyFieldName}Mock.Object";
		}

		public string GetVerifyAll (DependencyCallInfo oneDependencyCall)
		{
			return $"this.{oneDependencyCall.Dependency.PrivateReadOnlyFieldName}Mock.VerifyAll ();";
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
					paramsIsAny.Add ($"It.IsAny<{p.ParameterType.GetRealGenericTypeName ()}> ()");
					paramsDeclaration.Add ($"{p.ParameterType.GetRealGenericTypeName ()} {p.Name}");
					dummyStatements.Add ($"{p.Name} = {p.Name}");
				});

			if (methodReturnType == typeof (void))
			{
				statements.Add ($"this.{dependencyCallInfo.Dependency.PrivateReadOnlyFieldName}Mock");
				statements.Add ($"\t.Setup (d => d.{dependencyCallInfo.Method.Name} ({string.Join (", ", paramsIsAny)}))");
				statements.Add ($"\t.Callback (({string.Join (", ", paramsDeclaration)}) => {{\t\t// Callback statement is dummy. Please correct. E.g. a.Id = 1;");
				statements.Add ($"\t\t{string.Join (";\r\n\t\t\t\t\t", dummyStatements)};");
				statements.Add ("\t});");
			}
			else
			{
				statements.Add ($"this.{dependencyCallInfo.Dependency.PrivateReadOnlyFieldName}Mock");
				statements.Add ($"\t.Setup (d => d.{dependencyCallInfo.Method.Name} ({string.Join (", ", paramsIsAny)}))");
				statements.Add ($"\t.Returns (default ({methodReturnType.GetRealGenericTypeName ()}));\t\t// Please specify the correct return data here.");
			}

			return statements;
		}
	}
}