using System.Reflection;

using UnitTestGenerator.Logic.Entities;
using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Support.MockingLibrarySupport
{
    public sealed class NSubstituteSpecific
		: IMockLibrarySpecific
	{
		public MockingLibrary [] CanHandleMockingLibraries ()
		{
			return new [] { MockingLibrary.NSubstitute };
		}

		public bool IsMockingLibraryUsed { get; private set; }

		public string DeclareDependency (DependencyInfo dependency)
		{
			this.IsMockingLibraryUsed = true;
			return $"private {dependency.DependencyAbstractionType.GetRealGenericTypeName ()} {dependency.PrivateReadOnlyFieldName}Sub;";
		}

		public string AssignDependency (DependencyInfo dependency)
		{
			this.IsMockingLibraryUsed = true;
			return $"this.{dependency.PrivateReadOnlyFieldName}Sub = Substitute.For<{dependency.DependencyAbstractionType.GetRealGenericTypeName ()}> ();";
		}

		public string GetMockedObject (DependencyInfo dependency)
		{
			this.IsMockingLibraryUsed = true;
			return $"this.{dependency.PrivateReadOnlyFieldName}Sub";
		}

		public string GetVerifyAll (DependencyCallInfo oneDependencyCall)
		{
			return $"this.{oneDependencyCall.Dependency.PrivateReadOnlyFieldName}Sub.Received ();";
		}

		public IList<string> GetMockedDependencyCall (DependencyCallInfo dependencyCallInfo, bool voidAssertionsRequired)
		{
			var statements = new List<string> ();
			var methodReturnType = ((MethodInfo) dependencyCallInfo.Method).ReturnType;
			var paramsIsAny = new List<string> ();
			var paramsDeclaration = new List<string> ();
			var dummyStatements = new List<string> ();

			var argIndex = 1;

			dependencyCallInfo
				.Method
				.GetParameters ()
				.ToList ()
				.ForEach (p => {
					if (methodReturnType == typeof (void))
					{
						paramsIsAny.Add ($"Arg.Do<{p.ParameterType.GetRealGenericTypeName ()}> (a{argIndex} => {{\r\n\t\t\t\t\t\t\t\t\ta{argIndex} = a{argIndex}; // Callback statement is dummy. Please correct. E.g. a{argIndex}.Id = 1;\r\n\t\t\t\t\t\t\t}})");
						argIndex++;
					}
					else
					{
						paramsIsAny.Add ($"Arg.Any<{p.ParameterType.GetRealGenericTypeName ()}> ()");
					}

					paramsDeclaration.Add ($"{p.ParameterType.GetRealGenericTypeName ()} {p.Name}");
					dummyStatements.Add ($"{p.Name} = {p.Name};");
				});

			if (methodReturnType == typeof (void))
			{
				statements.Add ($"this.{dependencyCallInfo.Dependency.PrivateReadOnlyFieldName}Sub");
				statements.Add ($"\t.{dependencyCallInfo.Method.Name}");
				statements.Add ($"\t\t(");
				statements.Add ($"\t\t\t{string.Join (",\r\n\t\t\t\t\t\t", paramsIsAny)}");
				statements.Add ($"\t\t);");
			}
			else
			{
				statements.Add ($"this.{dependencyCallInfo.Dependency.PrivateReadOnlyFieldName}Sub");
				statements.Add ($"\t.{dependencyCallInfo.Method.Name} ({string.Join (", ", paramsIsAny)})");
				statements.Add ($"\t.Returns (default ({methodReturnType.GetRealGenericTypeName ()}));\t\t// Please specify the correct return data here.");
			}

			return statements;
		}
	}
}